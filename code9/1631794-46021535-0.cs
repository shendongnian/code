    Private Sub RichTextBox1_TextChanged(sender As Object, e As EventArgs) Handles RichTextBox1.TextChanged
        Dim img As New Bitmap(PictureBox1.Width, PictureBox1.Height)
        Using g = Graphics.FromImage(img)
            g.SmoothingMode = SmoothingMode.HighQuality
            g.DrawString(RichTextBox1.Text, RichTextBox1.Font, Brushes.Black, New PointF(10, 10))
        End Using
        'Dispose the existing image if there is one.'
        PictureBox1.Image?.Dispose()
        PictureBox1.Image = img
    End Sub
