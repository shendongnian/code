    public static Func<ServiceType, PayloadType, object> BuildServiceMethodInvocation<ServiceType>(MethodInfo serviceMethod)
    {
        var taskWrappingFunc = BuildTaskWrapperFunction(serviceMethod.ReturnType);
        return (service, payload) =>
        {
            try
            {
                // payload is mapped onto an object[]
                var parameters = ReadPayload(payload)
                var result = serviceMethod.Invoke(service, parameters);
                return taskWrappingFunc(result);
            }
            catch (TargetInvocationException e)
            {
                // bla bla bla handle the error
                throw;
            }
        };
    }
