    public class MyClass
    {
      private DateTime startTimer;
      private bool timerRun = false;
      public void Button_Clicked(...)
      {
        if(timerRun == false)
        {
          startTimer = DateTime.Now;
          timerRun = true;
        }
        else
        {
          DataTime endTimer = DateTime.Now;
          timerRun = false;
          TimeSpan span = endTimer - startTimer;
          Console.WriteLine(span.ToString());
        }
      }
    }
