    public class ReturnValueTupleAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            var content = actionExecutedContext?.Response?.Content as ObjectContent;
            if (!(content?.Formatter is JsonMediaTypeFormatter))
            {
                return;
            }
            var names = actionExecutedContext
                .ActionContext
                .ControllerContext
                .ControllerDescriptor
                .ControllerType
                .GetMethod(actionExecutedContext.ActionContext.ActionDescriptor.ActionName)
                ?.ReturnParameter
                ?.GetCustomAttribute<TupleElementNamesAttribute>()
                ?.TransformNames;
            var formatter = new JsonMediaTypeFormatter
            {
                SerializerSettings =
                {
                    ContractResolver = new ValueTuplesContractResolver(names),
                },
            };
            actionExecutedContext.Response.Content = new ObjectContent(content.ObjectType, content.Value, formatter);
        }
    }
