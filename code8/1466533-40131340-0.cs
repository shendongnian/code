    private int SearchValueRowIndex()
    {
        string searchValue = textBox1.Text;
    
        foreach (DataGridViewRow row in dataGridView1.Rows)
        {
            foreach (DataGridViewCell cell in row.Cells)
            {
                if (cell.Value != null && cell.Value.ToString() == searchValue)
                {
                    return cell.RowIndex;
                }
            }
        }
    
        // Not found
        return -1;
    }
