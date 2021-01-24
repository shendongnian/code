    private void button1_Click(object sender, EventArgs e){
    TimeSpan a = new TimeSpan(12, 00, 00);
    TimeSpan b = new TimeSpan(13, 00, 00);
    
    TimeSpan r = b - a;
    TimeSpan rr = new TimeSpan(r.Ticks / 2);
    
    MessageBox.Show("Test\n " + rr);   ///this is type TimeSpan 
    
    dateTimePicker.Value =  DateTime.Now.Date.AddMilliseconds(rr.TotalMilliseconds);
    }
