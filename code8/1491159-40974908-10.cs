    /// <summary>
    /// A Filter which can be applied to Web API controllers or actions which runs any FluentValidation Validators
    /// registered in the DependencyResolver to be run.  It's not currently possible to perform this validation in the
    /// standard Web API validation location, since this doesn't provide any way of instantiating Validators on a
    /// per-request basis, preventing injection of Unit of Work or DbContexts, for example.    ///
    /// </summary>
    public class FluentValidationActionFilter : BaseActionFilterAttribute
    {
        private static readonly List<HttpMethod> AllowedHttpMethods = new List<HttpMethod> { HttpMethod.Post, HttpMethod.Put, HttpMethod.Delete };
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="order">Order to run this filter</param>
        public FluentValidationActionFilter(int order = 1)
            : base(order)
        { }
        /// <summary>
        /// Pick out validation errors and turn these into a suitable exception structure
        /// </summary>
        /// <param name="actionContext">Action Context</param>
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            ModelStateDictionary modelState = actionContext.ModelState;
            // Only perform the FluentValidation if we've not already failed validation earlier on
            if (modelState.IsValid && AllowedHttpMethods.Contains(actionContext.Request.Method))
            {
                IDependencyScope scope = actionContext.Request.GetDependencyScope();
                var mvp = scope.GetService(typeof(IFluentValidatorProvider)) as IFluentValidatorProvider;
                if (mvp != null)
                {
                    ModelMetadataProvider metadataProvider = actionContext.GetMetadataProvider();
                    foreach (KeyValuePair<string, object> argument in actionContext.ActionArguments)
                    {
                        if (argument.Value != null && !argument.Value.GetType().IsSimpleType())
                        {
                            ModelMetadata metadata = metadataProvider.GetMetadataForType(
                                    () => argument.Value,
                                    argument.Value.GetType()
                                );
                            var validationContext = new InternalValidationContext
                            {
                                MetadataProvider = metadataProvider,
                                ActionContext = actionContext,
                                ModelState = actionContext.ModelState,
                                Visited = new HashSet<object>(),
                                KeyBuilders = new Stack<IKeyBuilder>(),
                                RootPrefix = String.Empty,
                                Provider = mvp,
                                Scope = scope
                            };
                            ValidateNodeAndChildren(metadata, validationContext, null);
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Validates a single node (not including children)
        /// </summary>
        /// <param name="metadata">Model Metadata</param>
        /// <param name="validationContext">Validation Context</param>
        /// <param name="container">The container.</param>
        /// <returns>True if validation passes successfully</returns>
        private static bool ShallowValidate(ModelMetadata metadata, InternalValidationContext validationContext, object container)
        {
            bool isValid = true;
            // Use the DependencyResolver to find any validators appropriate for this type
            IEnumerable<IValidator> validators = validationContext.Provider.GetValidators(metadata.ModelType, validationContext.Scope);
            foreach (IValidator validator in validators)
            {
                IValidatorSelector selector = new DefaultValidatorSelector();
                var context = new ValidationContext(metadata.Model, new PropertyChain(), selector);
                ValidationResult result = validator.Validate(context);
                foreach (var error in result.Errors)
                {
                    if (!validationContext.ModelState.ContainsKey(error.PropertyName))
                    {
                        validationContext.ModelState.Add(error.PropertyName, new ModelState
                        {
                            Value = new ValueProviderResult(error.AttemptedValue, error.AttemptedValue?.ToString(), CultureInfo.CurrentCulture)
                        });
                    }
                    validationContext.ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                    isValid = false;
                }
            }
            return isValid;
        }
        #region Copied from DefaultBodyModelValidator in Web API Source
        private bool ValidateElements(IEnumerable model, InternalValidationContext validationContext)
        {
            bool isValid = true;
            Type elementType = GetElementType(model.GetType());
            ModelMetadata elementMetadata = validationContext.MetadataProvider.GetMetadataForType(null, elementType);
            var elementScope = new ElementScope { Index = 0 };
            validationContext.KeyBuilders.Push(elementScope);
            foreach (object element in model)
            {
                elementMetadata.Model = element;
                if (!ValidateNodeAndChildren(elementMetadata, validationContext, model))
                {
                    isValid = false;
                }
                elementScope.Index++;
            }
            validationContext.KeyBuilders.Pop();
            return isValid;
        }
        private bool ValidateNodeAndChildren(ModelMetadata metadata, InternalValidationContext validationContext, object container)
        {
            bool isValid = true;
            object model = metadata.Model;
            // Optimization: we don't need to recursively traverse the graph for null and primitive types
            if (model != null && model.GetType().IsSimpleType())
            {
                return ShallowValidate(metadata, validationContext, container);
            }
            // Check to avoid infinite recursion. This can happen with cycles in an object graph.
            if (validationContext.Visited.Contains(model))
            {
                return true;
            }
            validationContext.Visited.Add(model);
            // Validate the children first - depth-first traversal
            var enumerableModel = model as IEnumerable;
            if (enumerableModel == null)
            {
                isValid = ValidateProperties(metadata, validationContext);
            }
            else
            {
                isValid = ValidateElements(enumerableModel, validationContext);
            }
            if (isValid && metadata.Model != null)
            {
                // Don't bother to validate this node if children failed.
                isValid = ShallowValidate(metadata, validationContext, container);
            }
            // Pop the object so that it can be validated again in a different path
            validationContext.Visited.Remove(model);
            return isValid;
        }
        private bool ValidateProperties(ModelMetadata metadata, InternalValidationContext validationContext)
        {
            bool isValid = true;
            var propertyScope = new PropertyScope();
            validationContext.KeyBuilders.Push(propertyScope);
            foreach (ModelMetadata childMetadata in validationContext.MetadataProvider.GetMetadataForProperties(
                metadata.Model, GetRealModelType(metadata)))
            {
                propertyScope.PropertyName = childMetadata.PropertyName;
                if (!ValidateNodeAndChildren(childMetadata, validationContext, metadata.Model))
                {
                    isValid = false;
                }
            }
            validationContext.KeyBuilders.Pop();
            return isValid;
        }
        #endregion Copied from DefaultBodyModelValidator in Web API Source
        #region Inaccessible Helper Methods from the Web API source needed by the other code here
        private interface IKeyBuilder
        {
            string AppendTo(string prefix);
        }
        private static string CreateIndexModelName(string parentName, int index) => CreateIndexModelName(parentName, index.ToString(CultureInfo.InvariantCulture));
        private static string CreateIndexModelName(string parentName, string index) => (parentName.Length == 0) ? $"[{index}]" : $"{parentName}[{index}]";
        private static string CreatePropertyModelName(string prefix, string propertyName)
        {
            if (String.IsNullOrEmpty(prefix))
            {
                return propertyName ?? String.Empty;
            }
            else if (String.IsNullOrEmpty(propertyName))
            {
                return prefix ?? String.Empty;
            }
            else
            {
                return prefix + "." + propertyName;
            }
        }
        private static Type GetElementType(Type type)
        {
            Contract.Assert(typeof(IEnumerable).IsAssignableFrom(type));
            if (type.IsArray)
            {
                return type.GetElementType();
            }
            foreach (Type implementedInterface in type.GetInterfaces())
            {
                if (implementedInterface.IsGenericType && implementedInterface.GetGenericTypeDefinition() == typeof(IEnumerable<>))
                {
                    return implementedInterface.GetGenericArguments()[0];
                }
            }
            return typeof(object);
        }
        private Type GetRealModelType(ModelMetadata metadata)
        {
            Type realModelType = metadata.ModelType;
            // Don't call GetType() if the model is Nullable<T>, because it will
            // turn Nullable<T> into T for non-null values
            if (metadata.Model != null && !metadata.ModelType.IsNullableValueType())
            {
                realModelType = metadata.Model.GetType();
            }
            return realModelType;
        }
        private class ElementScope : IKeyBuilder
        {
            public int Index { get; set; }
            public string AppendTo(string prefix) => CreateIndexModelName(prefix, Index);
        }
        private class PropertyScope : IKeyBuilder
        {
            public string PropertyName { get; set; }
            public string AppendTo(string prefix) => CreatePropertyModelName(prefix, PropertyName);
        }
        #endregion Inaccessible Helper Methods from the Web API source needed by the other code here
        private class InternalValidationContext
        {
            public HttpActionContext ActionContext { get; set; }
            public Stack<IKeyBuilder> KeyBuilders { get; set; }
            public ModelMetadataProvider MetadataProvider { get; set; }
            public ModelStateDictionary ModelState { get; set; }
            public IFluentValidatorProvider Provider { get; set; }
            public string RootPrefix { get; set; }
            public IDependencyScope Scope { get; set; }
            public HashSet<object> Visited { get; set; }
        }
