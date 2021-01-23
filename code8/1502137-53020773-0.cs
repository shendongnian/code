    private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
            {
                if(e.ColumnIndex == 4)
                {
                    e.Value = e.Value + "I Just changed";
                }
            }
