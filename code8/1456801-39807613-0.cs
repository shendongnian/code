    Public Class Form2
    
        Sub New()
            InitializeComponent()
    
            For Each c In Me.Controls.OfType(Of GroupBox)
                c.Hide()
            Next
            grpbox1.Show()
        End Sub
    
    End Class
