    Private Sub ListView1_DrawColumnHeader(ByVal sender As Object, ByVal e As DrawListViewColumnHeaderEventArgs) Handles ListView1.DrawColumnHeader
        Dim strFormat As New StringFormat()
        If e.Header.TextAlign = HorizontalAlignment.Center Then
            strFormat.Alignment = StringAlignment.Center
        ElseIf e.Header.TextAlign = HorizontalAlignment.Right Then
            strFormat.Alignment = StringAlignment.Far
        End If
        e.DrawBackground()
        e.Graphics.FillRectangle(Brushes.SteelBlue, e.Bounds)
        Dim headerFont As New Font("Arial", 8, FontStyle.Bold)
        e.Graphics.DrawString(e.Header.Text, headerFont, Brushes.White, e.Bounds, strFormat)
    End Sub
    Private Sub ListView1_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawListViewItemEventArgs) Handles ListView1.DrawItem
        e.DrawDefault = True
    End Sub
