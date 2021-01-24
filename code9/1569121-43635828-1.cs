    private void dataGridView1_CellFormatting(object sender, 
            System.Windows.Forms.DataGridViewCellFormattingEventArgs e)
        {
        	if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("YourColumnName"))
            {
                string val = e.Value.ToString();
            	e.Value = val.SubString(0, val.IndexOf(" "));
            }
        }
