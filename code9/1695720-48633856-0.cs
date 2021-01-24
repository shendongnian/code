    public class MyController : Controller
    {
        private readonly IValueService _valueServiceRepository;
        public MyController (IValueService _valueServiceRepository)
        {
            _valueServiceRepository = valueServiceRepository;
        }
      
    }
