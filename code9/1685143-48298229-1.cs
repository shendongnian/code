	public class AbstractModelBinderProvider<T> : IModelBinderProvider where T : class
	{
		public IModelBinder GetBinder(ModelBinderProviderContext context)
		{
			if (context == null)
				throw new ArgumentNullException(nameof(context));
			if (context.Metadata.ModelType != typeof(T))
				return null;
			var binders = new Dictionary<string, IModelBinder>();
			foreach (var type in typeof(AbstractModelBinderProvider<>).GetTypeInfo().Assembly.GetTypes())
			{
				var typeInfo = type.GetTypeInfo();
				if (typeInfo.IsAbstract || typeInfo.IsNested)
					continue;
				if (!(typeInfo.IsClass && typeInfo.IsPublic))
					continue;
				if (!typeof(T).IsAssignableFrom(type))
					continue;
				var metadata = context.MetadataProvider.GetMetadataForType(type);
				var binder = context.CreateBinder(metadata);
				binders.Add(type.FullName, binder);
			}
			return new AbstractModelBinder(context.MetadataProvider, binders);
		}
	}
	public class AbstractModelBinder : IModelBinder
	{
		private readonly IModelMetadataProvider _metadataProvider;
		private readonly Dictionary<string, IModelBinder> _binders;
		public AbstractModelBinder(IModelMetadataProvider metadataProvider, Dictionary<string, IModelBinder> binders)
		{
			_metadataProvider = metadataProvider;
			_binders = binders;
		}
		public async Task BindModelAsync(ModelBindingContext bindingContext)
		{
			var messageTypeModelName = ModelNames.CreatePropertyModelName(bindingContext.ModelName, "Type");
			var typeResult = bindingContext.ValueProvider.GetValue(messageTypeModelName);
			if (typeResult == ValueProviderResult.None)
			{
				bindingContext.Result = ModelBindingResult.Failed();
				return;
			}
			IModelBinder binder;
			if (!_binders.TryGetValue(typeResult.FirstValue, out binder))
			{
				bindingContext.Result = ModelBindingResult.Failed();
				return;
			}
			var type = Type.GetType(typeResult.FirstValue);
			var metadata = _metadataProvider.GetMetadataForType(type);
			ModelBindingResult result;
			using (bindingContext.EnterNestedScope(metadata, bindingContext.FieldName, bindingContext.ModelName, model: null))
			{
				await binder.BindModelAsync(bindingContext);
				result = bindingContext.Result;
			}
			bindingContext.Result = result;
			return;
		}
	}
