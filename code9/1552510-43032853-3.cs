    private void timer2_Tick(object sender, EventArgs e)
    {
        timer2.Interval = 1000;
        row.Cells[4].Value = TimeSpan
            .Parse(row.Cells[4].Value.ToString())
            .Subtract(TimeSpan.FromSeconds(1))
            .ToString(@"hh\:mm\:ss");
    }
