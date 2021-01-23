    public class Logic
    {
        public void DoSomething(ManualResetEvent cancel)
        {
            while (!WantHandle.WaitOne(cancel, 1))
            {
               ... Do stuff
            }
        }
    }       
