    public class TestClass : IDisposable
    {
         private Timer _timer;
    
         public TestClass()
         {
             _timer = new Timer(Callback, TimeSpan.FromMinutes(5), TimeSpan.FromMinutes(5));
         }
    
         private void Callback(object state)
         {
             //Do stuff here
         }
         public void Dispose() // the simplest IDisposable implementation
         {
             _timer?.Dispose();
         }
    }
    // Usage:
    using (var testClass = new TestClass())
    {
        
    }
