    public class LifetimeScopeJobDecorator : IJob
    {
        private readonly IJob _decoratee;
        private readonly Container _container;
        public LifetimeScopeJobDecorator(IJob decoratee, Container container)
        {
            _decoratee = decoratee;
            _container = container;
        }
        public void Execute(IJobExecutionContext context)
        {
                using (_container.BeginLifetimeScope())
                {
                    _decoratee.Execute(context);
                }
        }
    }
