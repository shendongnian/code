    public class EmailOutputComposite : IEmailOutputService
    {
        private readonly IEmailContext _emailContext;
        private readonly Dictionary<string, Func<IEmailOutputService>> _emailOutputServices;
        public EmailOutputComposite(
            IEmailContext emailContext, 
            Dictionary<string, Func<IEmailOutputService>> emailOutputServices)
        {
            _emailContext = emailContext;
            _emailOutputServices = emailOutputServices;
        }
        public bool Send(object m, object c) => Service.Send(m, c);
        IEmailOutputService Service => _emailOutputServices[_emailContext.GetProvider()]();
    }
