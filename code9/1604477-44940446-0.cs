    Class CustomLinkLabel
        Inherits LinkLabel
        Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
          'MyBase.OnPaint(e)
          Using B As New SolidBrush(Me.ForeColor)
              e.Graphics.DrawString(Me.Text, Me.Font, B, e.ClipRectangle.X, e.ClipRectangle.Y)
          End Using
      End Sub
    End Class
