Public Module ThreadSafety

    Delegate Sub SetText_Delegate(Of T As {New, Control}) _
        (ByVal [Form] As Form, ByVal [Control] As T, ByVal [Text] As String)

    Public Sub SetText(Of T As {New, Control})(ByVal [Form] As Form, ByVal [Control] As T, ByVal [Text] As String)

        If [Control].InvokeRequired Then
            Dim MyDelegate As New SetText_Delegate(Of T)(AddressOf SetText)
            [Form].Invoke(MyDelegate, New Object() {[Form], [Control], [Text]})
        Else
            [Control].Text = [Text]
        End If

    End Sub

    Delegate Sub ListViewUpdate_Delegate(ByVal [Form] As Form, ByVal listview As ListView, ByVal [text] As String, ByVal status As String, ByVal game As String)



    Public Sub ListViewUpdate(ByVal [Form] As Form, ByVal listview As ListView, ByVal [text] As String, ByVal status As String, optional ByVal game As String = "")

        'TODO: throws errors on already owned.

        If listview.InvokeRequired Then
            Dim myDelegate As New ListViewUpdate_Delegate(AddressOf ListViewUpdate)
            [Form].Invoke(myDelegate, New Object() {[Form], listview, [text], status, game})
        Else
            Dim index = listview.FindItemWithText([text]).Index
            listview.Items(index).SubItems(1).Text = status
            If game <> "" Then
                listview.Items(index).SubItems.Add(game)
            End If
        End If

    End Sub

End Module