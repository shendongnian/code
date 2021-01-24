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
            row.Selected = true;
            if(Decimal.Parse(row.Cells[3].Value.ToString()) > 0)
                row.Cells[2].Value = Decimal.Parse(row.Cells[2].Value.ToString()) - 1;
        }
        if (Decimal.Parse(row.Cells[3].Value.ToString()) <= 0)
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
