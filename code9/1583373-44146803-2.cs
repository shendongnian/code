    private void Form1_Load(object sender, EventArgs e)
    {
        lvTimeSheet.View = View.Details;
        lvTimeSheet.Columns.Add("Date");
        lvTimeSheet.Columns.Add("Start Time");
        lvTimeSheet.Columns.Add("Stop Time");
        lvTimeSheet.Columns.Add("Total Hours");
        lvTimeSheet.Columns.Add("Total Pay");
        // Auto-size the columns
        for (int i = 0; i < lvTimeSheet.Columns.Count; i++)
        {
            lvTimeSheet.Columns[i].Width = -2;
        }
    }
