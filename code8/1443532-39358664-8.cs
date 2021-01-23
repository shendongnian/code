    Private Sub cmdSelectDatabase_Click(sender As Object,
                                        e As EventArgs) Handles cmdSelectDatabase.Click
        FileSelect()
        cmdOpen.Select()
    End Sub
    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub
    Private Sub cmdOk_Click(sender As Object, e As EventArgs) Handles cmdOpen.Click
        Me.Cursor = Cursors.WaitCursor
        SetConnectionString()
        LoadMainApplication()
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub txtFile_Validated(sender As Object, e As EventArgs) Handles txtFile.Validated
        If txtFile.Text.Length = 0 Then
            cmdOpen.Enabled = False
            txtPassword.Enabled = False
        Else
            cmdOpen.Enabled = True
            txtPassword.Enabled = True
        End If
    End Sub
    Private Sub cmdNew_Click(sender As Object,
                             e As EventArgs) Handles cmdNew.Click
        CreateDatabase()
        SetConnectionString()
        LoadMainApplication()
    End Sub
    Private Sub CatchEnterKey(ByVal sender As Object,
        ByVal e As System.Windows.Forms.KeyPressEventArgs) _
            Handles txtFile.KeyPress, txtPassword.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            cmdOk_Click(sender, e)
            e.Handled = True
            Exit Sub
        End If
    End Sub
