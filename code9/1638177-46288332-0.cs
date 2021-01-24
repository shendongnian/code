    public class ConfigurableCacheResponseAttribute : CacheResponseAttribute
    {
        //Property injection
        public IApplicationConfig ApplicationConfig { get; set; }
    
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            if (this.ApplicationConfig.Get<bool>("CashingEnabled"))
            {
                base.OnActionExecuted(actionExecutedContext);
            }
        }
    
        public override Task OnActionExecutedAsync(HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
        {
            if (this.ApplicationConfig.Get<bool>("CashingEnabled"))
            {
                return base.OnActionExecutedAsync(actionExecutedContext, cancellationToken);
            }
    
            return Task.CompletedTask;
        }
            
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (this.ApplicationConfig.Get<bool>("CashingEnabled"))
            {
                base.OnActionExecuting(actionContext);
            }
        }
    
        public override Task OnActionExecutingAsync(HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            if (this.ApplicationConfig.Get<bool>("CashingEnabled"))
            {
                return base.OnActionExecutingAsync(actionContext, cancellationToken);
            }
    
            return Task.CompletedTask;
        }
    }
