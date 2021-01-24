    public class MyController : Controller
    {
        private readonly ISession _session;
        public MyController(ISession session)
        {
            _session = session;
        }
    }
