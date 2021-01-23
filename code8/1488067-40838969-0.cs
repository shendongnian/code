    public class CheckDbDate
    {
       private Timer _timer;
       public event EventHandler DateReached;
    
       public CheckDbDate()
       {
          _timer = new Timer();
          _timer.Intervall = 500; //ms
          _timer.Elapsed += (sender, e) => CheckDate();
          _timer.Start();
       }
    
       public void CheckDate()
       {
          //Check your Database Date value
          if (DateTime.Now.CompareTo(dbDate) >= 0)
          {
             DateReached?.Invoke(this, new EventArgs());
          }
       }
    }
