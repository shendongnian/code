    {
       App.Timer1Running = true;    
       …
       try
       {
          await Task.Delay(1000, App.tokenSource1.Token);
       }
       catch(TaskCanceledException ex){}
       App.TimerSeconds--;       
       App.Timer1Running = false;    
    }
