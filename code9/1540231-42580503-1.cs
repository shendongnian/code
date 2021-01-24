    public static Func<ServiceType, PayloadType, Task> BuildServiceMethodInvocation<ServiceType>(MethodInfo serviceMethod)
    {
        return (service, payload) =>
        {
            try
            {
                // payload is mapped onto an object[]
                var parameters = ReadPayload(payload)
                var result = serviceMethod.Invoke(service, parameters);
                // forward the task if it already *is* a task
                var task = (result as Task) ?? Task.FromResult(result);
                return task;
            }
            catch (TargetInvocationException e)
            {
                // bla bla bla handle the error
                throw;
            }
        };
    }
