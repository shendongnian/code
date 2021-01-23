    private void Form1_Load(object sender, EventArgs e)
    {
        dataGridView1.AllowUserToAddRows = false;
        dataGridView1.Rows.Add();
    }
    private void MoveToNextCell()
    {
        int col = dataGridView1.CurrentCell.ColumnIndex;
        int row = dataGridView1.CurrentCell.RowIndex;
        if (col < dataGridView1.ColumnCount - 1)
        {
            col++;
        }
        else
        {
            col = 0;
            row++;
        }
        if (row == dataGridView1.RowCount)
        {
            dataGridView1.Rows.Add();
        }
        dataGridView1.CurrentCell = dataGridView1[col, row];
    }
    private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyData == Keys.Enter)
        {
            MoveToNextCell();
            e.Handled = true;
        }
    }
    private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
    {
        if (!isCellClicked)
        {
            MoveToNextCell();
        }
    }
    private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
    {
        if (dataGridView1.CurrentCell.ColumnIndex != e.ColumnIndex || dataGridView1.CurrentCell.RowIndex != e.RowIndex)
        {
            isCellClicked = true;
        }
    }
    private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
    {
        isCellClicked = false;
    }
