    public class CustomModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
                throw new ArgumentNullException(nameof(bindingContext));
            ValueProviderResult values = bindingContext.ValueProvider.GetValue("ModelType");
            if (values.Length == 0)
                return Task.CompletedTask;
            string typeString = values.FirstValue;
            Type type = Type.GetType(
                "Magic.Core.Models." + typeString + ", Magic.Core.Models",
                true
            );
            object model = Activator.CreateInstance(type);
            //*get form values from provider
            var content = model as ContentModel;
            if(content != null)
            {
                var provider = bindingContext.ValueProvider;
                var contentType = provider.GetValue("ContentType");
                content.ContentType = contentType != null ? contentType.ToString() : string.Empty;
                var name = provider.GetValue("Name");
                content.Name = name != null ? name.ToString() : string.Empty;
            }
            //*/
            var metadataProvider = (IModelMetadataProvider)bindingContext.HttpContext.RequestServices.GetService(typeof(IModelMetadataProvider));
            bindingContext.ModelMetadata = metadataProvider.GetMetadataForType(type);
            bindingContext.Result = ModelBindingResult.Success(model);
            return Task.CompletedTask;
        }
    }
