    public class AutofacMessageDispatcher : IAutoSubscriberMessageDispatcher
    {
        readonly ILifetimeScope _component;
        readonly IMessageContextFactory _contextFactory;
        public const string PerMessageLifeTimeScopeTag = "AutofacMessageScope";
        public const string GlobalPipeTag = "global";
    
        public AutofacMessageDispatcher(ILifetimeScope component, IMessageContextFactory contextFactory)
        {
            _component = component;
            _contextFactory = contextFactory;
        }
    
        static IEnumerable<IErrorHandler> GetErrorHandlers<TConsumer>(TConsumer consumer, IComponentContext scope)
        {
            var errorHandlers = consumer.GetType()
                .GetTypeInfo().GetAttributes<ErrorHandlerAttribute>()
                .OrderBy(attribute => attribute.Order)
                .Select(attribute => attribute.Initialize((IErrorHandler) scope.Resolve(attribute.ErrorHandlerType)))
                .Union(scope.ResolveNamed<IEnumerable<IErrorHandler>>(GlobalPipeTag), a => a.GetType()); // perform the distinction in the union on GetType so we only get 1 handler of the same type
    
            if (consumer is IErrorHandler consumerAsErrorHandler)
                errorHandlers = errorHandlers.Concat(new[] { consumerAsErrorHandler });
    
            return errorHandlers;
        }
        
        static IEnumerable<IPipe> GetPipeLine<TConsumer>(TConsumer consumer, IComponentContext scope)
        {
            var pipeLine = consumer.GetType()
                .GetTypeInfo().GetAttributes<PipeAttribute>()
                .OrderBy(attribute => attribute.Order)
                .Select(attribute => attribute.Initialize((IPipe) scope.Resolve(attribute.PipeType)))
                .Union(scope.ResolveNamed<IEnumerable<IPipe>>(GlobalPipeTag), a => a.GetType()); // perform the distinction in the union on GetType so we only get 1 handler of the same type
    
            return pipeLine;
        }
    
        [HandleProcessCorruptedStateExceptions]
        public void Dispatch<TMessage, TConsumer>(TMessage message)
            where TMessage : class
            where TConsumer : IConsume<TMessage>
        {
            using (var scope = _component.BeginLifetimeScope(PerMessageLifeTimeScopeTag, _contextFactory.RegisterMessageContext(typeof(TConsumer), message)))
            {
                var consumer = scope.Resolve<TConsumer>();
                var pipeLine = GetPipeLine(consumer, scope).ToArray();
                pipeLine.Each(p => p.OnBeforeConsume(consumer, message));
    
                Exception exception = null;
                try
                {
                    consumer.Consume(message);
                }
                catch (Exception e) when (GetErrorHandlers(consumer, scope).Any(p => p.OnError(consumer, message, e)))
                {
                    exception = e;
                }
                pipeLine.Reverse().Each(p => p.OnAfterConsume(consumer, message, exception));
            }
        }
        
        [HandleProcessCorruptedStateExceptions]
        public async Task DispatchAsync<TMessage, TConsumer>(TMessage message)
            where TMessage : class
            where TConsumer : IConsumeAsync<TMessage>
        {
            using (var scope = _component.BeginLifetimeScope(PerMessageLifeTimeScopeTag, _contextFactory.RegisterMessageContext(typeof(TConsumer), message)))
            {
                var consumer = scope.Resolve<TConsumer>();
                var pipes = GetPipeLine(consumer, scope).ToArray();
    
                Exception exception = null;
    
                foreach (var hook in pipes)
                    await hook.OnBeforeConsumeAsync(consumer, message);
                try
                {
                    await consumer.Consume(message);
                }
                catch (Exception e) when (GetErrorHandlers(consumer, scope).Any(p => p.OnErrorAsync(consumer, message, e)))
                {
                    exception = e;
                }
                foreach (var hook in pipes.Reverse())
                    await hook.OnAfterConsumeAsync(consumer, message, exception);
            }
        }
    }        
    
    public interface IMessageContextFactory
    {
        Action<ContainerBuilder> RegisterMessageContext<TMessage>(Type consumerType, TMessage message) where TMessage : class;
    }
    
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class ErrorHandlerAttribute : Attribute  
    {
        public ErrorHandlerAttribute(Type errorHandlerType, int order = 0)
        {
            ErrorHandlerType = errorHandlerType;
            Order = order;
        }
    
        public Type ErrorHandlerType { get; set; }
        public int Order { get; set; }
    
        public virtual IErrorHandler Initialize(IErrorHandler handler)
        {
            return handler;
        }
    }
    
    public interface IErrorHandler
    {
        bool OnError<TMessage, TConsumer>(TConsumer consumer, TMessage message, Exception exception)
            where TMessage : class
            where TConsumer : IConsume<TMessage>;
    
        bool OnErrorAsync<TMessage, TConsumer>(TConsumer consumer, TMessage message, Exception exception)
            where TMessage : class
            where TConsumer : IConsumeAsync<TMessage>;
    }
    
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class PipeAttribute : Attribute  
    {
        public PipeAttribute(Type pipeType, int order = 0)
        {
            PipeType = pipeType;
            Order = order;
        }
    
        public Type PipeType { get; set; }
        public int Order { get; set; }
    
        public IPipe Initialize(IPipe pipe)
        {
            return pipe;
        }
    }
    
    public interface IPipe
    {
        void OnBeforeConsume<TMessage, TConsumer>(TConsumer consumer, TMessage message)
            where TMessage : class
            where TConsumer : IConsume<TMessage>;
    
        void OnAfterConsume<TMessage, TConsumer>(TConsumer consumer, TMessage message, [CanBeNull] Exception exception)
            where TMessage : class
            where TConsumer : IConsume<TMessage>;
    
        Task OnBeforeConsumeAsync<TMessage, TConsumer>(TConsumer consumer, TMessage message)
            where TMessage : class
            where TConsumer : IConsumeAsync<TMessage>;
    
        Task OnAfterConsumeAsync<TMessage, TConsumer>(TConsumer consumer, TMessage message, [CanBeNull] Exception exception)
            where TMessage : class
            where TConsumer : IConsumeAsync<TMessage>;
    }
    
    public interface IMessageContext
    {
            object Message { get; }
    }
    public class MessageContext : IMessageContext
    {
        public MessageContext(object message)
        {
            Message = message;
        }
    
        public object Message { get; set; }
    }
    
    public class MessageContextFactory : IMessageContextFactory
    {
        readonly ILogger _logger;
    
        public MessageContextFactory()
        {
            _logger = logger;
        }
    
        public Action<ContainerBuilder> RegisterMessageContext<TMessage>(Type consumerType, TMessage message) where TMessage : class
        {
            return builder =>
            {
                builder.RegisterInstance(new MessageContext(message)).As<IMessageContext>().AsSelf();
                var forContext = _logger.ForContext(message.GetType());
                builder.RegisterInstance(forContext).As<ILogger>().AsSelf();
            };
        }
    }
    
    
    public interface IMessageContextFactory
    {
        Action<ContainerBuilder> RegisterMessageContext<TMessage>(Type consumerType, TMessage message) where TMessage : class;
    }
