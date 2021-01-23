    List<DataGridViewColumn> Cols = dataGridView1.Columns.Cast<DataGridViewColumn>().Where(c => c.HeaderText.Contains("fish")).ToList();
    
                if (Cols.Count > 0)
                {
                    dataGridView1.FirstDisplayedScrollingColumnIndex = Cols[0].Index;
                }
