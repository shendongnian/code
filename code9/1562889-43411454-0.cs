     private bool _timerEnable =false;
     public bool TimerEnable{
          get{ return _timerEnable;}
          set{
                timer1.Enabled = value;
                _timerEnable = value;
          }
     }
