    public void YourOriginalMethod()
    {
       YourUtilityClass util = new YourUtilityClass(HttpContext.Current);
       var task = Task.Run(() =>
       {
           var test = util.MethodWithContext();
       });
       if (!task.Wait(TimeSpan.FromSeconds(5)))
           throw new Exception("Timeout");
     }
    
    public class YourUtilityClass
    {
        private readonly HttpContext _ctx;
        public YourUtilityClass(HttpContext ctx)
        {
           if(ctx == null)
              throw new ArgumentNullException(nameof(ctx));
           _ctx = ctx;
        }
 
        public void object MethodWithContext()
        {
           return _ctx.Items["Test"];
        }
        // You can add more methods here...
    }
