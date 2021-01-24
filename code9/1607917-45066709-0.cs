    public class Dispatcher : IDispatcher
    {
        private const string HandleMethodName = "Handle";
        private readonly IServiceProvider _serviceProvider;
        public Dispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public TResponse Request<TResponse>(IQuery<TResponse> query)
        {
            Type queryType = query.GetType();
            // used for when OperationResult<object> was used
            Type operationResultTrueReturnType = typeof(TResponse);
            if (operationResultTrueReturnType == typeof(object))
            {
                operationResultTrueReturnType = queryType.GetInterface(typeof(IQuery<>).Name).GenericTypeArguments[0];
            }
            Type handlerType = typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), operationResultTrueReturnType);
            return ExecuteHandler<TResponse>(handlerType, query, queryType);
        }
        public OperationResult Submit(ICommand command)
        {
            Type commandType = command.GetType();
            var baseTypeAttribute = (CommandBaseTypeAttribute)commandType.GetCustomAttributes(typeof(CommandBaseTypeAttribute), false).FirstOrDefault();
            if (baseTypeAttribute != null)
                commandType = baseTypeAttribute.BaseType;
            try
            {
                Type handlerType = typeof(ICommandHandler<>).MakeGenericType(commandType);
                return ExecuteHandler<OperationResult>(handlerType, command, commandType);
            }
            catch (InvalidOperationException ex)
            {
                return new OperationResult(OperationResultStatus.Failure, ex.Message);
            }
        }
        public OperationResult<TResult> Submit<TResult>(ICommand<TResult> command)
        {
            Type commandType = command.GetType();
            var baseTypeAttribute = (CommandBaseTypeAttribute)commandType.GetCustomAttributes(typeof(CommandBaseTypeAttribute), false).FirstOrDefault();
            if (baseTypeAttribute != null)
                commandType = baseTypeAttribute.BaseType;
            try
            {
                Type handlerType = typeof(ICommandHandler<,>).MakeGenericType(commandType, typeof(TResult));
                return ExecuteHandler<OperationResult<TResult>>(handlerType, command, commandType);
            }
            catch (InvalidOperationException ex)
            {
                return new OperationResult<TResult>(OperationResultStatus.Failure, default(TResult), ex.Message);
            }
        }
        private TReturnValue ExecuteHandler<TReturnValue>(Type handlerType, object argument, Type argumentType)
        {
            object handler = _serviceProvider.GetService(handlerType);
            if (handler == null)
                throw new ArgumentException("Handler not registered for type " + argumentType.Name);
            try
            {
                MethodInfo handleMethod = handlerType.GetMethod(HandleMethodName, new[] { argumentType });
                return (TReturnValue)handleMethod.Invoke(handler, new[] { argument });
            }
            catch (TargetInvocationException ex)
            {
                if (ex.InnerException != null)
                    throw ex.InnerException;
                throw;
            }
        }
    }
