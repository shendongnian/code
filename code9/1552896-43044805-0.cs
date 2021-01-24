    var stopwatch = System.Diagnotics.Stopwatch.StartNew();
    private void zaman_Tick(object sender, EventArgs e)
    {   
        lblzaman.Text = stopwatch.Elapsed.ToString();
    }
    
