    public class MyBootstrapper: DefaultNancyBootstrapper
    {
    
        protected override void RequestStartup(TinyIoCContainer container, IPipelines pipelines, NancyContext context)
        {
            pipelines.OnError += ((ctx, e) =>
            {
    
                if (context.Request.Headers.Accept.Any(c => c.Item1.Equals("text/html")))
                {
                     IViewFactory viewFactory = container.Resolve<IViewFactory>();
                     return viewFactory.RenderView("Error", new {Message = ex.Message}, new ViewLocationContext() { Context = context, ModuleName = "", ModulePath = "" });
                }
    
            });
        }
    }
