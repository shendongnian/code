    public static Func<ServiceType, PayloadType, Task<object> > BuildServiceMethodInvocation<ServiceType>(MethodInfo serviceMethod)
    {
        return (service, payload) =>
        {
            try
            {
                // payload is mapped onto an object[]
                var parameters = ReadPayload(payload)
                var result = serviceMethod.Invoke(service, parameters);
                return Task.FromResult<object>(result);
            }
            catch (TargetInvocationException e)
            {
                // bla bla bla handle the error
                throw;
            }
        };
    }
