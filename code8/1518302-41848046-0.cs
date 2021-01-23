     public class MyClass : IDisposable
        {
            private Timer _timer = new Timer();
            public void Dispose()
            {
                //This way you can dispose your disposable resources used in class properly.
                _timer.Dispose();
            }
        }
