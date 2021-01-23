    public partial class MyContext
    {
        partial void OnContextCreated()
        {         
              DbInterception.Add(new FtsInterceptor());
        }
    }
