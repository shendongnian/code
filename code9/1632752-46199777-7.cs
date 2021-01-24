    //Redefine IModelBinder so that when the ModelBinderProvider Casts it to an 
    //IModelBinder it uses our new BindModelAsync
    public class InterfaceBinder : ComplexTypeModelBinder, IModelBinder
    {
        protected TypeResolverOptions _options;
        //protected Dictionary<Type, ModelMetadata> _modelMetadataMap;
        protected IDictionary<ModelMetadata, IModelBinder> _propertyMap;
        protected ModelBinderProviderContext _binderProviderContext;
        protected InterfaceBinder(TypeResolverOptions options, ModelBinderProviderContext binderProviderContext, IDictionary<ModelMetadata, IModelBinder> propertyMap) : base(propertyMap)
        {
            this._options = options;
            //this._modelMetadataMap = modelMetadataMap;
            this._propertyMap = propertyMap;
            this._binderProviderContext = binderProviderContext;
        }
        public InterfaceBinder(TypeResolverOptions options, ModelBinderProviderContext binderProviderContext) :
            this(options, binderProviderContext, new Dictionary<ModelMetadata, IModelBinder>())
        {
        }
        public new Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var propertyNames = bindingContext.HttpContext.Request.Query
                .Select(x => x.Key.Trim());
            var modelName = bindingContext.ModelName;
            if (false == string.IsNullOrEmpty(modelName))
            {
                modelName = modelName + ".";
                propertyNames = propertyNames
                    .Where(x => x.StartsWith(modelName, StringComparison.OrdinalIgnoreCase))
                    .Select(x => x.Remove(0, modelName.Length));
            }
            //split always returns original object if empty
            propertyNames = propertyNames.Select(p => p.Split('.')[0]);
            var type = ResolveTypeFromCommonProperties(propertyNames, bindingContext.ModelType);
            ModelBindingResult result;
            ModelStateDictionary modelState;
            object model;
            using (var scope = CreateNestedBindingScope(bindingContext, type))
            {
                 base.BindModelAsync(bindingContext);
                result = bindingContext.Result;
                modelState = bindingContext.ModelState;
                model = bindingContext.Model;
            }
            bindingContext.ModelState = modelState;
            bindingContext.Result = result;
            bindingContext.Model = model;
            return Task.FromResult(0);
        }
        protected override object CreateModel(ModelBindingContext bindingContext)
        {
            return Activator.CreateInstance(bindingContext.ModelType);
        }
        protected NestedScope CreateNestedBindingScope(ModelBindingContext bindingContext, Type type)
        {
            var modelMetadata = this._binderProviderContext.MetadataProvider.GetMetadataForType(type);
            
            //TODO: don't create this everytime this should be cached
            this._propertyMap.Clear();
            for (var i = 0; i < modelMetadata.Properties.Count; i++)
            {
                var property = modelMetadata.Properties[i];
                var binder = this._binderProviderContext.CreateBinder(property);
                this._propertyMap.Add(property, binder);
            }
            return bindingContext.EnterNestedScope(modelMetadata, bindingContext.ModelName, bindingContext.ModelName, null);
        }
        protected Type ResolveTypeFromCommonProperties(IEnumerable<string> propertyNames, Type interfaceType)
        {
            var types = this.ConcreteTypesFromInterface(interfaceType);
            //Find the type with the most matching properties, with the least unassigned properties
            var expectedType = types.OrderByDescending(x => x.GetProperties().Select(p => p.Name).Intersect(propertyNames).Count())
                .ThenBy(x => x.GetProperties().Length).FirstOrDefault();
            expectedType = interfaceType.CopyGenericParameters(expectedType);
            if (null == expectedType)
            {
                throw new Exception("No suitable type found for models");
            }
            return expectedType;
        }
        public List<Type> ConcreteTypesFromInterface(Type interfaceType)
        {
            var interfaceTypeInfo = interfaceType.GetTypeInfo();
            if (interfaceTypeInfo.IsGenericType && (false == interfaceTypeInfo.IsGenericTypeDefinition))
            {
                interfaceType = interfaceTypeInfo.GetGenericTypeDefinition();
            }
            this._options.TypeResolverMap.TryGetValue(interfaceType, out var types);
            return types ?? new List<Type>();
        }
    }
