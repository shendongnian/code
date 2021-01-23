    private void timer1_Tick(object sender, EventArgs e)
    {
         endTime = DateTime.Now;
         TimeSpan span = endTime - startTime; //gets difference between now and when the program was started
         Title.Content = span.ToString().Substring(0, 8); //gets first 8 characters (taking out milliseconds)
     }
