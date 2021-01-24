    public class BaseController
    {
        protected IDateProvider _dateProvider;
        protected BaseController(IDateProvider dateProvider)
        {
            _dateProvider = dateProvider;
        }
    }
