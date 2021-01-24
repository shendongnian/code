    DataGridViewCellStyle selectedStyle = new DataGridViewCellStyle();
    selectedStyle.BackColor = Color.LemonChiffon;
    selectedStyle.ForeColor = Color.OrangeRed;
   
    DataGridViewCellStyle defaultStyle = new DataGridViewCellStyle();
    defaultStyle.BackColor = System.Drawing.Color.White;
    defaultStyle.ForeColor = Control.DefaultForeColor;
    
    foreach (DataGridViewRow row in iCBOMHDataGridView.Rows)
    {
        if ((string)row.Cells[2].Value == textBox2.Text)
        {
            foreach (DataGridViewCell col in row.Cells.AsParallel())
                col.Style = selectedStyle;
        }
        else
        {
            foreach (DataGridViewCell col in row.Cells.AsParallel())
                col.Style = defaultStyle;
        } 
    }
