    public class Proxy : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            var wrapper = new EventHandlerTaskAsyncHelper(DoAsyncWork);
            context.AddOnBeginRequestAsync(wrapper.BeginEventHandler, wrapper.EndEventHandler);
        }
    
        async Task DoAsyncWork(object sender, EventArgs e)
        {
            // await... anything
        }
    }
