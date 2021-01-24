    public class Serial
    {
        SerialPort s;
        public Serial()
        {
            InitSerialPort();
            s.DataReceived += dataReciver;
    
        }
        pri
    
        private void dataReciver(object sender, SerialDataReceivedEventArgs e)
        {
          lock (obj) 
        {
              while (s.BytesToRead >0)
               {
                   var line = s.ReadLine();
                   if(line=="hello")
                   {
                       Thread.Sleep(500);
                       s.WriteLine("hello to you friend");
                  }
                  else  //......
            }       
               }
        }
    
    }
