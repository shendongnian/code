    public class ValuesController : ApiController
    {
        public async Task<string> Get()
        {
            await DoSomething();
            return ControllerContext?.ToString();  
        }
        Task DoSomething()=> Task.Delay(new System.TimeSpan(0, 0, 0, 0, 100));
    }
