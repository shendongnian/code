    private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        if (this.dataGridView1.Columns[e.ColumnIndex].Name == "Gender")
        {
            if (e.Value != null)
            {
                int gender = int.Parse(e.Value);
                if (gender == 1)
                {
                    e.Value = "Male";
                }
                else
                {
                    e.Value = "Female";
                }            
                e.FormattingApplied = true;
            }
        }    
    }
