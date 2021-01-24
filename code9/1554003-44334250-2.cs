    public class ContentParameterBinding : HttpParameterBinding
    {
        private struct AsyncVoid{}
        public ContentParameterBinding(HttpParameterDescriptor descriptor) : base(descriptor)
        {
        }
        public override Task ExecuteBindingAsync(ModelMetadataProvider metadataProvider,
                                                    HttpActionContext actionContext,
                                                    CancellationToken cancellationToken)
        {
            var binding = actionContext.ActionDescriptor.ActionBinding;
            if (binding.ParameterBindings.Length > 1 ||
                actionContext.Request.Method == HttpMethod.Get)
            {
                var taskSource = new TaskCompletionSource<AsyncVoid>();
                taskSource.SetResult(default(AsyncVoid));
                return taskSource.Task as Task;
            }
            var type = binding.ParameterBindings[0].Descriptor.ParameterType;
            if (type == typeof(HttpContent))
            {
                SetValue(actionContext, actionContext.Request.Content);
                var tcs = new TaskCompletionSource<object>();
                tcs.SetResult(actionContext.Request.Content);
                return tcs.Task;
            }
            throw new InvalidOperationException("Only string and byte[] are supported for [NakedBody] parameters");
        }
    }
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Parameter, AllowMultiple = false, Inherited = true)]
    public sealed class FromContentAttribute : ParameterBindingAttribute
    {
        public override HttpParameterBinding GetBinding(HttpParameterDescriptor parameter)
        {
            if (parameter == null)
                throw new ArgumentException("Invalid parameter");
            return new ContentParameterBinding(parameter);
        }
    }
