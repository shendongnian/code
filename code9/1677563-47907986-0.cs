    public class ApiShell : IApiShell
    {
        _IDisposable _webApp;
        public void Start()
        {
            _webApp = WebApp.Start<Startup>("http://localhost:9090");
            Console.WriteLine($"Web server running at 'http://localhost:9090'");
        }
        public void Stop()
        {
            _webApp.Dispose();
        }
    }
    public class HostService
    {
        public void Start()
        {
            IoC.Container.Resolve<IApiShell>().Start();  //start web app
        }
    
        public void Stop()
        {
            IoC.Container.Resolve<IApiShell>().Stop();  //stop web app
        }
    }
