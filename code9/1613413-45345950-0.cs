    public class MyDeepDeepDependency
    {
        public MyDeepDeepDependency(IHttpContextAccessor contextAccessor)
        {
            var dep = contextAccessor.HttpContext.RequestServices.GetService(typeof(IMyDependency));
        }
    }
