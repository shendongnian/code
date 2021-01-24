    // In Form_Load or another init method
    Timer tRequest = new Timer();
    tRequest.Interval = 500;
    tRequest.Tick += TRequest_Tick;
    
    private void TRequest_Tick(object sender, EventArgs e)
    {
         var sendTimes = times.Where(t => t.AddMilliseconds(500) < DateTime.Now && t.AddMilliseconds(500) > DateTime.Now);
                
         foreach(DateTime sendTime in sendTimes)
         {
             SendRequest();
         }
    }
