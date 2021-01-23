	Private Sub DataGridView1_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
		'put here your code to add CurrentCell to maze array
	
        Me.PaintCurrentCell()
    End Sub
    Private Sub DataGridView1_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles DataGridView1.KeyDown
        If e.KeyCode = Keys.Space Then Me.PaintCurrentCell()
    End Sub
    Private Sub DataGridView1_SelectionChanged(sender As Object, e As System.EventArgs) Handles DataGridView1.SelectionChanged
        Me.DataGridView1.CurrentCell.Style.SelectionBackColor = Me.DataGridView1.CurrentCell.Style.BackColor
    End Sub
    Private Sub PaintCurrentCell()
        Me.DataGridView1.CurrentCell.Style.BackColor = Color.Black
        Me.DataGridView1.CurrentCell.Style.SelectionBackColor = Color.Black
    End Sub
