    int Seconds = 1;
    Private void WaitNSeconds(int seconds)
        { 
           if (seconds < 1) return;
             DateTime _desired = DateTime.Now.AddSeconds(seconds);
             while (DateTime.Now < _desired) {
                  System.Windows.Forms.Application.DoEvents();
             }
         }
