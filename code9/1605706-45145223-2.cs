    public class AsyncInstanceProvider : StandardInstanceProvider
    {
        public override object GetInstance(
            IInstanceResolver instanceResolver, MethodInfo methodInfo, object[] arguments)
        {
            object result = base.GetInstance(
                instanceResolver, methodInfo, arguments);
            if (ReturnsTaskResult(methodInfo))
            {
                return CreateFinishedTask(methodInfo, result);
            }
            return result;
        }
        protected override Type GetType(MethodInfo methodInfo, object[] arguments)
        {
            if (ReturnsTaskResult(methodInfo))
            {
                return methodInfo.ReturnType.GenericTypeArguments[0];
            }
            return base.GetType(methodInfo, arguments);
        }
        private bool ReturnsTaskResult(MethodInfo methodInfo)
        {
            return (methodInfo.ReturnType.IsGenericType 
                    && methodInfo.ReturnType.GetGenericTypeDefinition() == typeof(Task<>));
        }
        private object CreateFinishedTask(MethodInfo methodInfo, object result)
        {
            var openGenericMethod = typeof(Task).GetMethod("FromResult");
            var closedGenericMethod = openGenericMethod.MakeGenericMethod(
                methodInfo.ReturnType.GenericTypeArguments[0]);
            return closedGenericMethod.Invoke(null, new object[1] { result });
        }
    }
