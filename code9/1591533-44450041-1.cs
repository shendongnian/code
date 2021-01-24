    private void HideRow(string word)
    {
        foreach (DataGridViewRow row in dataGridView1.Rows)
        {
            foreach (DataGridViewCell cell in row.Cells)
            {
                var value = Convert.ToString(cell.Value);
                if (word != value)
                {
                    row.Visible = false;
                    break;
                }
            }
        }
    }
