    Private Sub DataGridView1_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        'put here your code to add CurrentCell to maze array
        'set black background
        Me.DataGridView1.CurrentCell.Style.BackColor = Color.Black
        Me.DataGridView1.CurrentCell = Nothing
    End Sub
