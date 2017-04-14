Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Threading
Imports ManagedWinapi.Windows

Public Class FormMain
    Public WithEvents Steam As New SteamActivator(False)
    Private Property CurrKeyIndex As Integer = 0
    Private Property InvalidAttemps As Integer = 0
    Private Property MaxActivations = 50
    Private ReadOnly _loadedKeys As New List(Of String)
    Public Sub GetEm()
        If Steam.FindActivation() Then
            Steam.StartActivate()
        End If
    End Sub
    Private Sub steamActivator_ActivateClosed(ByVal key As String) Handles Steam.ActivateClosed
        Try
            Select Case key
                Case 0
                    Debug.WriteLine("closed.")
                    WriteToLog("Successful : " & key)
                    ListViewUpdate(Me, ListView1, key, "Activated!")
                    DoNextKey()
                Case Else
                    WriteToLog("Successful : " & key)
                    ListViewUpdate(Me, ListView1, key, "Activated!")
                    DoNextKey()
            End Select
        Catch ex As Exception
        End Try
    End Sub
    Private Sub steamActivator_ActivateDetected(ByVal activateWindow As SystemWindow) Handles Steam.ActivateDetected
        If Not CurrKeyIndex >= _loadedKeys.Count Then
            ClickNext(2)
            Thread.Sleep(1000)
            Steam.InputSteamKey(_loadedKeys(CurrKeyIndex))
            Thread.Sleep(1000)
            ClickNext(2)
            Thread.Sleep(1000)
            ClickCancel()
        End If
    End Sub
    Public Sub WriteToLog(ByVal msg As String)
        My.Computer.FileSystem.WriteAllText(Application.StartupPath & "/activation.log", vbCrLf & msg & vbCrLf, True)
    End Sub
    Private Sub steamActivator_AlreadyActive(game As String, key As String) Handles Steam.AlreadyActive
        Try
            WriteToLog("Failure (Already Owned) : " & game & " : " & key)
            ListViewUpdate(Me, ListView1, key, "Already activated!", game)
            '_loadedKeys.RemoveAt(_currKeyIndex)
            InvalidAttemps += 1
            DoNextKey()
        Catch ex As Exception
        End Try
    End Sub

    Public Sub DoNextKey()
        Thread.Sleep(1200)
        Debug.WriteLine(_loadedKeys(CurrKeyIndex))
        If InvalidAttemps >= 5 Then
            labelStatus.Text = "Status: Too many invalid attempts."
            Exit Sub
        ElseIf CurrKeyIndex >= MaxActivations Then
            labelStatus.Text = "Status: Max allowed activations."
            Exit Sub
        Else
            If CurrKeyIndex < _loadedKeys.Count Then
                CurrKeyIndex += 1
                Steam.OpenActivation()
            End If
            labelStatus.Text = "Status: " & CurrKeyIndex & "/" & _loadedKeys.Count & " finished."
        End If
    End Sub

    Public Sub ClickCancel()
        Steam.LeftMouseClick(Steam.CancelPoint)
    End Sub

    Public Sub ClickNext(Optional ByVal times As Integer = 0)
        For i = 0 To times
            Thread.Sleep(300)
            Steam.LeftMouseClick(Steam.NextPoint)
        Next
    End Sub

    Public AlreadyOwned As String = Application.StartupPath & "\alreadyowned.txt"

    Public Owned As String() = File.ReadAllText(Application.StartupPath & "\alreadyowned.txt").Split(":")

    Public Function IsAlreadyOwned(ByVal key As String) As Boolean
        Return Owned.Any(Function(ownedkey) ownedkey.Contains(key))
    End Function
    Private Sub ButtonParse_Click(sender As Object, e As EventArgs) Handles ButtonParse.Click
        ListView1.Items.Clear()
        _loadedKeys.Clear()
        CurrKeyIndex = 0
        InvalidAttemps = 0
        Dim keys As String = File.ReadAllText("C:\jan18keys.txt")
        Dim regExKeys As New Regex("(\w{5})-(\w{5})-(\w{5})")
        Dim keysFound As MatchCollection = regExKeys.Matches(keys)
        If keysFound.Count <> 0 Then
            For Each key As Match In keysFound
                If Steam.CheckKeyFormat(key.Value) Then
                    If Not IsAlreadyOwned(key.Value) Then
                        _loadedKeys.Add(key.Value)
                        ListView1.Items.Add(key.Value).SubItems.Add("Unchecked")
                        Debug.WriteLine(key.Value)
                    End If
                End If
            Next
        End If
        labelStatus.Text = "Status: Loaded " & _loadedKeys.Count & " keys!"
        ListView1.Columns(0).AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
    End Sub
    Private Sub SlcClose1_Click(sender As Object, e As EventArgs) Handles SlcClose1.Click
        End
    End Sub
    Private Sub OnActivate_Click(sender As Object, e As EventArgs) Handles OnActivate.Click
        Select Case OnActivate.Checked
            Case True
                If _loadedKeys.Count <> 0 Then
                    Steam = New SteamActivator(True)
                    Steam.OpenActivation()
                    OnActivate.Checked = True
                Else
                    labelStatus.Text = "Status: Load keys first!"
                    OnActivate.Checked = False
                End If
            Case False
        End Select
    End Sub
    Private Sub AlreadyOwnedToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AlreadyOwnedToolStripMenuItem.Click
        Dim input = InputBox("Enter game name")
        Select Case input
            Case ""
                Exit Sub
            Case Else
                My.Computer.FileSystem.WriteAllText(AlreadyOwned, input & ": " & ListView1.SelectedItems(0).Text & vbCrLf, True)
                ListView1.SelectedItems(0).Remove()
        End Select
    End Sub
    Private Sub opCPMon_Click(sender As Object, e As EventArgs) Handles opCPMon.Click
        If opCPMon.Checked Then
            Timer1.Enabled = True
        Else
            Timer1.Enabled = False
        End If
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim key = Clipboard.GetText()
        If Steam.CheckKeyFormat(key) Then
            If Not IsAlreadyOwned(key) Then
                _loadedKeys.Add(key)
                ListView1.Items.Add(key).SubItems.Add("Unchecked")
            End If
        End If
        Clipboard.Clear()
    End Sub
End Class