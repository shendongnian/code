    public class SwaggerValueTupleFilter : IOperationFilter
    {
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            var action = apiDescription.ActionDescriptor;
            var controller = action.ControllerDescriptor.ControllerType;
            var method = controller.GetMethod(action.ActionName);
            var names = method?.ReturnParameter?.GetCustomAttribute<TupleElementNamesAttribute>()?.TransformNames;
            if (names == null)
            {
                return;
            }
            var responseType = apiDescription.ResponseDescription.DeclaredType;
            FieldInfo[] tupleFields;
            var props = new Dictionary<string, string>();
            var isEnumer = responseType.GetInterface(nameof(IEnumerable)) != null;
            if (isEnumer)
            {
                tupleFields = responseType
                    .GetGenericArguments()[0]
                    .GetFields();
            }
            else
            {
                tupleFields = responseType.GetFields();
            }
            for (var i = 0; i < tupleFields.Length; i++)
            {
                props.Add(names[i], tupleFields[i].FieldType.GetFriendlyName());
            }
            object result;
            if (isEnumer)
            {
                result = new List<Dictionary<string, string>>
                {
                    props,
                };
            }
            else
            {
                result = props;
            }
            operation.responses.Clear();
            operation.responses.Add("200", new Response
            {
                description = "OK",
                schema = new Schema
                {
                    example = result,
                },
            });
        }
