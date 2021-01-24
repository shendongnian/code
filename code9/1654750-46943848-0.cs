    class DebugTracer : IServiceClientTracingInterceptor
    {
        public void Information(string message)
        {
            Debug.WriteLine(message);
        }
        public void TraceError(string invocationId, Exception exception)
        {
            Debug.WriteLine("Exception in {0}: {1}", invocationId, exception);
        }
        public void ReceiveResponse(string invocationId, HttpResponseMessage response)
        {
            string requestAsString = (response == null ? string.Empty : response.AsFormattedString());
            Debug.WriteLine("invocationId: {0}\r\nresponse: {1}", invocationId, requestAsString);
        }
        public void SendRequest(string invocationId, HttpRequestMessage request)
        {
            string requestAsString = (request == null ? string.Empty : request.AsFormattedString());
            Debug.WriteLine("invocationId: {0}\r\nrequest: {1}", invocationId, requestAsString);
        }
        public void Configuration(string source, string name, string value)
        {
            Debug.WriteLine("Configuration: source={0}, name={1}, value={2}", source, name, value);
        }
        public void EnterMethod(string invocationId, object instance, string method, IDictionary<string, object> parameters)
        {
            Debug.WriteLine("invocationId: {0}\r\ninstance: {1}\r\nmethod: {2}\r\nparameters: {3}",
                invocationId, instance, method, parameters.AsFormattedString());
        }
        public void ExitMethod(string invocationId, object returnValue)
        {
            string returnValueAsString = (returnValue == null ? string.Empty : returnValue.ToString());
            Debug.WriteLine("Exit with invocation id {0}, the return value is {1}",
                invocationId, returnValueAsString);
        }
    }
