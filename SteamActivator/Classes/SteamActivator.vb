Imports System.Runtime.InteropServices
Imports System.Threading
Imports System.Timers
Imports WindowsInput
Imports ManagedWinapi.Windows

Public Class SteamActivator

    <DllImport("user32.dll", SetLastError:=True)> _
    Private Shared Function SetCursorPos(ByVal x As Integer, ByVal y As Integer) As Boolean
    End Function
    Declare Function apimouse_event Lib "user32.dll" Alias "mouse_event" (ByVal dwFlags As Int32, ByVal dX As Int32, ByVal dY As Int32, ByVal cButtons As Int32, ByVal dwExtraInfo As Int32) As Boolean
    <Flags()> _
    Public Enum MouseEventFlags As UInteger
        MOUSEEVENTF_ABSOLUTE = &H8000
        MOUSEEVENTF_LEFTDOWN = &H2
        MOUSEEVENTF_LEFTUP = &H4
        MOUSEEVENTF_MIDDLEDOWN = &H20
        MOUSEEVENTF_MIDDLEUP = &H40
        MOUSEEVENTF_MOVE = &H1
        MOUSEEVENTF_RIGHTDOWN = &H8
        MOUSEEVENTF_RIGHTUP = &H10
        MOUSEEVENTF_XDOWN = &H80
        MOUSEEVENTF_XUP = &H100
        MOUSEEVENTF_WHEEL = &H800
        MOUSEEVENTF_HWHEEL = &H1000
    End Enum
    Public Property Enabled As Boolean
    Public Event ActivateDetected(ByVal win As SystemWindow)
    Public Event ActivateClosed(ByVal key As String)
    Public Event AlreadyActive(ByVal game As String, ByVal key As String)
    Public Event SteamTitle(ByVal msg As String)
    Public PosTop, PosLeft As Int32
    Public Property NextPoint As POINT
    Public Property CancelPoint As POINT
    Public Property SteamKey As String
    Private ReadOnly _hashHwnds As New HashSet(Of String)
    Private WithEvents _procMon As New Timers.Timer(200)
    Private WithEvents _hwndWatcher As New Timers.Timer(200)

    Private ReadOnly _steamIdentifier As Predicate(Of SystemWindow) = Function(x) x.ClassName.Contains("USurface_")

    Public Sub New(ByVal enabled As Boolean)
        Me.Enabled = enabled
        AddHandler _procMon.Elapsed, New ElapsedEventHandler(AddressOf procMon_Elapsed)
        AddHandler _hwndWatcher.Elapsed, New ElapsedEventHandler(AddressOf hwndWatcher_Elapsed)
        _procMon.Enabled = enabled
    End Sub

    Public Sub InputSteamKey(ByVal key As String)
        SteamKey = key
        AppActivate("Product Activation")
        Thread.Sleep(300)
        InputSimulator.SimulateTextEntry(key)
    End Sub
    ''' <summary>
    ''' Watch for any product activation windows to occur. Add it to the hashset and raise the event of it's detection.
    ''' Once it's detected and the event has been raised, pass this to the hwndWatcher to keep track of the windows status.
    ''' </summary>
    Private Sub procMon_Elapsed(ByVal sender As Object, ByVal e As ElapsedEventArgs) Handles _procMon.Elapsed
        Dim steamWindows As SystemWindow() = SystemWindow.FilterToplevelWindows(_steamIdentifier)
        If steamWindows Is Nothing Then Return
        For Each window As SystemWindow In steamWindows
            If window.Title = "Product Activation" Then
                If _hashHwnds.Add(window.HWnd) Then
                    window.TopMost = True
                    NextPoint = New POINT(window.Position.Right - 132, window.Position.Bottom - 22)
                    CancelPoint = New POINT(window.Position.Right - 40, window.Position.Bottom - 25)
                    _hwndWatcher.Enabled = True
                    RaiseEvent ActivateDetected(window)
                End If
            End If
        Next
    End Sub
    Private _alreadyActive As Boolean
    ''' <summary>
    ''' Keep track of the window handle that is temporarily stored in the hashset. If it's not there anymore, the windows closed. Raise the event.
    ''' </summary>
    Private Sub hwndWatcher_Elapsed(sender As Object, e As ElapsedEventArgs) Handles _hwndWatcher.Elapsed
        If _hashHwnds.Count <> 0 Then
            Dim winMonitor As New SystemWindow(_hashHwnds(0))
            If winMonitor.Title = "" Then
                If _hashHwnds.Remove(_hashHwnds(0)) Then
                    _hwndWatcher.Enabled = False
                    If _alreadyActive Then
                        RaiseEvent ActivateClosed(0)
                    Else
                        RaiseEvent ActivateClosed(SteamKey)
                    End If
                End If
            End If
            If winMonitor.Title.Contains("Install") Then
                Dim gameTitle = winMonitor.Title.Split("-")(1).Trim()
                If _hashHwnds.Remove(_hashHwnds(0)) Then
                    _hwndWatcher.Enabled = False
                    RaiseEvent AlreadyActive(gameTitle, SteamKey)
                    _alreadyActive = True
                    winMonitor.SendClose()
                End If
            End If
        End If
    End Sub
    Public Function CheckKeyFormat(ByVal sKey As String)

        Dim allowedChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ-0123456789_"
        Dim isValid As Boolean
        If sKey.Length > 9 AndAlso sKey.Length < 32 Then
            If sKey.Contains("-") Then
                Dim splitKey = sKey.Split("-")
                If splitKey.Any(Function(keySection) Not Len(keySection) = 5) Then
                    Return False
                End If
            End If
            isValid = sKey.Trim.All(Function(charKey) allowedChars.Contains(charKey))
        End If
        Return isValid
    End Function
    Private Function ActiveSteamWin() As String
        Dim pr As Process() = Process.GetProcessesByName("Steam")
        Dim han As IntPtr = pr(0).MainWindowHandle
        Dim win = New SystemWindow(han)
        Return win.Title
    End Function
    Public Sub StartActivate()
        Dim pr As Process() = Process.GetProcessesByName("Steam")
        Dim han As IntPtr = pr(0).MainWindowHandle
        Dim win = New SystemWindow(han)
        If win.Title = "Product Activation" Then
            If win.Visible Then
                NextPoint = New POINT(win.Position.Right - 132, win.Position.Bottom - 22)
                ClickMultiple(1, NextPoint)
            End If
        End If
    End Sub
    Public Sub OpenActivation()
        Dim p As New Process
        p.StartInfo.FileName = "steam://open/activateproduct"
        p.Start()
    End Sub
    Public Sub ClickMultiple(ByVal times As Integer, ByVal clickPoint As POINT)
        For i = 0 To times
            Thread.Sleep(100)
            LeftMouseClick(clickPoint)
        Next
        RaiseEvent SteamTitle("key")
    End Sub
    Public Function FindActivation() As Object
        Dim steamPoint As POINT = GetMainSteamPos()
        LeftMouseClick(steamPoint)
        Thread.Sleep(200)
        Dim newPoint = New POINT(steamPoint.X + 26, steamPoint.Y + 38)
        LeftMouseClick(newPoint)
        Thread.Sleep(200)
        If ActiveSteamWin() = "Product Activation" Then
            Return True
        End If
        Return False
    End Function

    Public Function SetCurPointPos(ByVal cursorPoint As POINT) As Boolean
        Return SetCursorPos(cursorPoint.X, cursorPoint.Y)
    End Function
    Public Sub OpenProdActivate(ByVal targetPoint As POINT, Optional ByVal changedPoint As POINT = Nothing)
        LeftMouseClick(targetPoint)
        Thread.Sleep(1000)
        If Not changedPoint.Equals(Nothing) Then
            Dim newPoint As New POINT(changedPoint.X + 50, changedPoint.Y + 38)
            LeftMouseClick(newPoint)
        End If
    End Sub
    Public Function GetMainSteamPos(Optional ByVal flashWindow As Boolean = False) As POINT
        Try
            Dim pr As Process() = Process.GetProcessesByName("Steam")
            If flashWindow Then
                Call New SystemWindow(pr(0).MainWindowHandle).Highlight()
            End If
            Dim han As IntPtr = pr(0).MainWindowHandle
            Dim win = New SystemWindow(han)
            PosLeft = win.Position.Left + 150
            PosTop = win.Position.Top + 26
            Return New POINT(PosLeft, PosTop)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Sub LeftMouseClick(ByVal point As POINT)
        SetCursorPos(point.X, point.Y)
        apimouse_event(MouseEventFlags.MOUSEEVENTF_LEFTDOWN, point.X, point.Y, 0, 0)
        apimouse_event(MouseEventFlags.MOUSEEVENTF_LEFTUP, point.X, point.Y, 0, 0)
    End Sub

End Class
