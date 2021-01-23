        private void setTimerRepeat(object sender, DoWorkEventArgs e){
            DateTime begin = DateTime.Now;
            bool isRunning = true;
            int sleep=500;
            while(isRunning){
                int milliSeconds = DateTime.Now.Subtract(begin).TotalMilliSeconds;
                if(milliSeconds > 9000){
                    sleep=10;
                }else{
                    sleep=500;
                }
                if(milliSeconds=>10000){//if you get drift here, it should be consistent - adjust firing time downward to offset drift (change sleep to a multiple such that sleep%yourNumber==0)
                    begin = DateTime.Now;
                    Task.Run(()=>fireEvent());
                }
                Thread.Sleep(sleep);
                    
            }
       }
    }
            
