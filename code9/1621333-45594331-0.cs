    private List<String> GetSpans()
    {
        var timeSpanList = new List<string>;
        foreach (DataGridViewRow row in dataGridView1.Rows)
        {
            TimeSpan span = (DateTime.Now - Convert.ToDateTime(row.Cells[2].Value));
    
            timeSpanList.Add(String.Format("{0} hours, {1} minutes, {2} seconds",
                span.Hours, span.Minutes, span.Seconds));
        }
    }
