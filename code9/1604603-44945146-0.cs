        Thread t = new Thread(() => plot(28.5231445, 77.40388525, "17/06/20", "17:00:50", "82"));
        public void plot(double temp_lat, double temp_long, string temp_date, string temp_time, string temp_bty_value)
        {
            if (this.InvokeRequired)
            {
               this.Invoke((MethodInvoker)(() => 
                   { 
                        this.Close();  
                   }));
            } 
            else { 
               this.Close(); 
            }
         }
