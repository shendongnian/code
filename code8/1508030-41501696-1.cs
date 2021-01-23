    private void dataGridView1_CellFormatting(object sender, 
                                              DataGridViewCellFormattingEventArgs e)
    {
        if (this.dataGridView1.Columns[e.ColumnIndex].Name.Equals("LapTime"))
        {
            var hundredSeconds = (int)e.Value;
            var milliseconds = (double)(hundredSeconds * 10.0);
            var timespan = TimeSpan.FromMilliseconds(milliseconds);
            e.Value = timespan.ToString(@"mm\:ss\.fff");
            // will produce 02:03.45
        }
    }
