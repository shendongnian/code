    public class TestViewModel
    {
        private readonly Dispatcher _dispatcher = Dispatcher.CurrentDispatcher;
        public TestViewModel()
        {
            IsSplashVisible = true;
            ThreadPool.QueueUserWorkItem(o =>
            {
                var result = getDataFromDatabase();
                
                _dispatcher.Invoke(() => 
                {
                   LstUsers = result;
                   IsSplashVisible = false;
                });            
            });
        }
        ...
    }
