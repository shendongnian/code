    Private Sub SetLabelRangeColor(ByVal [End] As Integer, ByVal Color As Color)
        SetLabelRangeColor(1, [End], Color)
    End Sub
    Private Sub SetLabelRangeColor(ByVal Start As Integer, ByVal [End] As Integer, ByVal Color As Color)
        If Start > [End] Then Throw New ArgumentOutOfRangeException
        For x = Start To [End]
            Dim TargetLabel As Label = TryCast(Me.Controls("Label" & x), Label)
            If TargetLabel IsNot Nothing Then
                TargetLabel.ForeColor = Color
            End If
        Next
    End Sub
