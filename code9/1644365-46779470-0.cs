    Public Class DataGridView_Filter
    Inherits DataGridView
    Private Sub DataGridView_Filter_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Me.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        Me.ColumnHeadersHeight = 60
        Me.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
    End Sub
    End Class
