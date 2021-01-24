    private void TextBox_KeyPress(object sender, KeyPressEventArgs e)        
    {
        string value = TextBox.Text;
        foreach(GridViewRow row in GridView.Rows)
        {
            for(int i = 0; i < GridView.Columns.Count; i++)
            {
                string cellText = row.Cells[i].Text;
                if(cellText == value)
                {
                    // Highlights the entire row
                    row.DefaultCellStyle.SelectionBackColor = Color.Yellow;
                    break;
                }
            }
        }
    }
