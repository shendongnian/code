    DateTime startTime = DateTime.Now;
    private void timer1_Tick(object sender, EventArgs e)
        {
    DateTime endTime = DateTime.Now
    TimeSpan span = endTime.Subtract( startTime );
    if(span.Minutes % 5 == 0){
            circularProgressBar1.Increment(1);
            circularProgressBar1.Text =    circularProgressBar1.Value.ToString();
            circularProgressBar1.SuperscriptText = "%";
     }
    }
    
