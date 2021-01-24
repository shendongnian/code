    private void dataGridView1_CellFormatting(object sender, System.Windows.Forms.DataGridViewCellFormattingEventArgs e)
    {
        if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("sex"))
        {
            int? sex = e.Value as int?;
            // replace statement checks with your own conditions
            if(sex == 0)
            {
                e.Value  = "Male";
            }
            else if(sex == 1)
            {
                e.Value = "Female";
            }
            else
            {
                e.Value = "Unknown";
            }
        }
    }
