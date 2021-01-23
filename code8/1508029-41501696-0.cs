    private void dataGridView1_CellFormatting(object sender, 
                                              DataGridViewCellFormattingEventArgs e)
    {
        if (this.dataGridView1.Columns[e.ColumnIndex].Name.Equals("Artist"))
        {
            var hundredSeconds = (int)e.Value;
            var milliseconds = (double)(hundredSeconds * 10.0);
            var timespan = TimeSpan.FromMilliseconds(milliseconds);
            e.Value = timespan.ToString(@"hh\:mm\:ss\:fff");
        }
    }
