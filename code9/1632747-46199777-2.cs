    public class TypeResolverOptions : ITypeResolverOptions {
        public Dictionary<Type, List<Type>> TypeResolverMap { get; set; } = new Dictionary<Type, List<Type>>();
    }
    public abstract class InterfaceBinder : IModelBinder
    {
        protected TypeResolverOptions _options;
        protected DynamicConverter _converter;
        public InterfaceBinder(TypeResolverOptions options)
        {
            this._options = options ?? new TypeResolverOptions();
            this._converter = new DynamicConverter(x => this.CanResolve(x), (r, o, i, s) => this.ReadJson(r, o, i, s));
        }
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var values = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            if (values.Length == 0)
            {
                return Task.CompletedTask;
            }
            // Attempt to parse
            var stringValue = values.FirstValue;
            try
            {
                var parsedObject = JObject.Parse(stringValue);
                 //parsedObject.Properties().First().ToObject
                var propertyNames = parsedObject.Properties().Select(x => x.Name).ToList();
                var expectedType = this.GetDefaultExpectedType(propertyNames, bindingContext.ModelType);
                var serializer = this.GetSerializer();
                var reader = new StringReader(stringValue);
                var result = serializer.Deserialize(reader, expectedType);
                //var result = JsonConvert.DeserializeObject(stringValue, expectedType);
                bindingContext.ModelState.SetModelValue(bindingContext.ModelName, result, stringValue);
                bindingContext.Result = ModelBindingResult.Success(result);
            }
            catch (Exception ex)
            {
                //TODO: Parse the message to add Model State Validation
            }
            return Task.CompletedTask;
        }
        public virtual JsonSerializer GetSerializer()
        {
            var serializer = new JsonSerializer();
            serializer.Converters.Add(new DynamicConverter(x => CanResolve(x), (r,o,i,s) => this.ReadJson(r,o,i,s)));
            return serializer;
        }
        public bool CanResolve(Type type)
        {
            var typeInfo = type.GetTypeInfo();
            if (false == typeInfo.IsInterface)
            {
                return false;
            }
            if(typeInfo.IsGenericType && (false == typeInfo.IsGenericTypeDefinition))
            {
                type = typeInfo.GetGenericTypeDefinition();
            }
            return this._options.TypeResolverMap.ContainsKey(type);
        }
        private object ReadJson (JsonReader reader, Type interfaceType, Object obj, JsonSerializer serializer)
        {
            //TODO this is really terrible and slow your constucting remaining object each deserialization
            var jObj = JObject.Load(reader);
            var propertyNames = jObj.Properties().Select(x => x.Name);
            var expectedType = this.GetDefaultExpectedType(propertyNames, interfaceType);
            return serializer.Deserialize(jObj.CreateReader(), expectedType);
        }
        protected Type GetDefaultExpectedType(IEnumerable<string> propertyNames, Type interfaceType)
        {
            var types = this.ConcreteTypesFromInterface(interfaceType);
            //Find the type with the most matching properties, with the least unassigned properties
            var expectedType = types.OrderByDescending(x => x.GetProperties().Select(p => p.Name).Intersect(propertyNames).Count())
                .ThenBy(x => x.GetProperties().Length).FirstOrDefault();
            expectedType = ConvertType(expectedType, interfaceType);
            if (null == expectedType)
            {
                throw new Exception("No suitable type found for models");
            }
            return expectedType;
        }
        public abstract List<Type> ConcreteTypesFromInterface(Type interfaceType);
        public abstract Type ConvertType(Type expectedType, Type interfaceType);
    }
    public static class TypeExtensions
    {
        public static bool IsSubclassOfRawGeneric(this Type generic, Type toCheck)
        {
            while (toCheck != null && toCheck != typeof(object))
            {
                var cur = toCheck.GetTypeInfo().IsGenericType ? toCheck.GetGenericTypeDefinition() : toCheck;
                if (generic == cur)
                {
                    return true;
                }
                toCheck = toCheck.GetTypeInfo().BaseType;
            }
            return false;
        }
    }
