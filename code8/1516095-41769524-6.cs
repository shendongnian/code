    public class WortService { 
        public LWContext dbLW = new LWContext(); 
        public Wort GetWort(int? id) 
        {
            if (id == null)
                 throw new ArgumentNullException("id");
 
            var wort = (from s in dbLW.Worts where s.ID == id select s).FirstOrDefault(); 
            return wort; 
        } 
    }
    public class ArgumentExceptionFilterAttribute : ExceptionFilterAttribute 
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            if (context.Exception is ArgumentException)
            {
                context.Response = new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }
    }
