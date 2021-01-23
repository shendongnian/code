    public class MyService : IMyService
    {
        private readonly IActionContextAccessor _actionContextAccessor;
        public MyService(IActionContextAccessor actionContextAccessor)
        {
            _actionContextAccessor = actionContextAccessor;
        }
        public bool IsValid
        {
            get
            {
                return _actionContextAccessor.ActionContext.ModelState.IsValid;
            }
        }
    }
