            bool timerRun = false;
                DateTime startTimer = new DateTime(), endTimer = new DateTime();
                TimeSpan span;
                
                if(timerRun == false){
                    startTimer = DateTime.Now;
                    timerRun = true;
                }
                else{
                    endTimer = DateTime.Now;
                    timerRun = false;
                }
     span = endTimer - startTimer; //can also be span = endTimer.Subtract(startTimer);
        Console.WriteLine(span.ToString());
