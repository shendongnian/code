    public class HomeController : Controller
    {
        private readonly Context context;
        public HomeController(Context ctx)
        {
            context = ctx;
        }
        public List<Worker> GetWorkers()
        {
            return context.Workers.ToList();
        }
    }
