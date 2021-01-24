    private void timer2_Tick(object sender, EventArgs e)
    {
        timer2.Interval = 1000;
        //The cell Value at this command line instance equals "00:30:00"
        ti = row.Cells[4].Value.ToString();
        TimeSpan tint = TimeSpan.Parse(ti);
        // Subtract one second
        TimeSpan updated = tint.Subtract(TimeSpan.FromSeconds(1));
        //Change cell value after subtracting
        row.Cells[4].Value = updated.ToString(@"hh\:mm\:ss");
    }
