    public class JsonValidatingModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var result = base.BindModel(controllerContext, bindingContext);
            if (!IsJsonRequest(controllerContext))
            {
                return result;
            }
            if (!bindingContext.ModelMetadata.RequestValidationEnabled)
            {
                return result;
            }
            if (result != null)
            {
                EnsureRequestFieldIsValid(controllerContext, result);
            }
            return result;
        }
        static void EnsureRequestFieldIsValid(ControllerContext controllerContext, object result)
        {
            int index;
            // abusing RequestValidationSource enum
            if (!RequestValidator.Current.InvokeIsValidRequestString(
                controllerContext.HttpContext.ApplicationInstance.Context,
                result.ToString(), RequestValidationSource.Form, null, out index))
            {
                throw new HttpRequestValidationException(
                    "A potentially dangerous value was detected from the client ");
            }
        }
        static bool IsJsonRequest(ControllerContext controllerContext)
        {
            return controllerContext.HttpContext.Request.ContentType.StartsWith("application/json", StringComparison.OrdinalIgnoreCase);
        }
