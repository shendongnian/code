    DateTime startTime = dateTimePicker1.Value;
    DateTime endTime = dateTimePicker2.Value;
    
    TimeSpan duration = new TimeSpan(endTime.Ticks - startTime.Ticks);
    textBox1.Text = duration.ToString(); 
 
