    public class MyController : Controller
    {
        protected readonly MyDalClass dal;
        public MyController(MyDalClass dal)
        {
            this.dal = dal;
        }
        ...
    }
