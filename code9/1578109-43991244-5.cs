    public class ParamsAttribute : ParameterBindingAttribute {
        public override HttpParameterBinding GetBinding(HttpParameterDescriptor parameter) {
            //Check to make sure that it is a params array
            if (parameter.ParameterType.IsArray &&
                parameter.GetCustomAttributes<ParamArrayAttribute>().Count() > 0) {
                return new ParamsParameterBinding(parameter);
            }
            return parameter.BindAsError("invalid params binding");
        }
    }
    public class ParamsParameterBinding : HttpParameterBinding {
        public ParamsParameterBinding(HttpParameterDescriptor descriptor)
            : base(descriptor) {
        }
        public override async Task ExecuteBindingAsync(ModelMetadataProvider metadataProvider, HttpActionContext actionContext, CancellationToken cancellationToken) {
            var descriptor = this.Descriptor;
            var paramName = descriptor.ParameterName;
            var arrayType = descriptor.ParameterType;
            var elementType = arrayType.GetElementType();
            try {
                //can it be converted to array
                var obj = await actionContext.Request.Content.ReadAsAsync(arrayType);
                actionContext.ActionArguments[paramName] = obj;
                return;
            } catch { }
            try {
                //Check if single and wrap in array
                var obj = await actionContext.Request.Content.ReadAsAsync(elementType);
                var array = Array.CreateInstance(elementType, 1);
                array.SetValue(obj, 0);
                actionContext.ActionArguments[paramName] = array;
                return;
            } catch { }
        }
    }
