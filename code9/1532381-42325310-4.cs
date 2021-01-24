    Private Sub Form1_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dim c As Form = TryCast(sender, Form)
        If c Is Nothing Then
            MessageBox.Show("sender is not a Form")
            Return
        End If
        Try
            StackingControl1.RemoveForm(c)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    End Class
