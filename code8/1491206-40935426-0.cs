    Private Sub ComboBox1_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ComboBox1.Validating
        If Not CType(sender, ComboBox).Items.Contains(CType(sender, ComboBox).Text) Then
            MsgBox("Not a valid item!")
            e.Cancel = True
        End If
    End Sub
