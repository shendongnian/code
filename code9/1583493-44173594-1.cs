    using Utils;
    namespace WcfService2
    {
        [ServiceErrorBehaviour(typeof(HttpErrorHandler))]
        public class BaseService
        {
        }
    }
