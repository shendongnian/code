    [SessionState(SessionStateBehavior.ReadOnly)]
    public class TestController : Controller
    {
        public async Task<string> Index()
        {
            return await Task.Run(() =>
            {
                ...
            });
        }
    }
