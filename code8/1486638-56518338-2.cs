    using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
    public class LocalizedValidationMetadataProvider : IValidationMetadataProvider
    {
        public LocalizedValidationMetadataProvider()
        {
        }
        public void CreateValidationMetadata(ValidationMetadataProviderContext context)
        {
            if (context.Key.ModelType.GetTypeInfo().IsValueType && context.ValidationMetadata.ValidatorMetadata.Where(m => m.GetType() == typeof(RequiredAttribute)).Count() == 0)
                context.ValidationMetadata.ValidatorMetadata.Add(new RequiredAttribute());
            foreach (var attribute in context.ValidationMetadata.ValidatorMetadata)
            {
                var tAttr = attribute as ValidationAttribute;
                if (tAttr?.ErrorMessage == null && tAttr?.ErrorMessageResourceName == null)
                {
                    var name = tAttr.GetType().Name;
                    if (Resources.ValidationsMessages.ResourceManager.GetString(name) != null)
                    {
                        tAttr.ErrorMessageResourceType = typeof(Resources.ValidationsMessages);
                        tAttr.ErrorMessageResourceName = name;
                        tAttr.ErrorMessage = null;
                    }
                }
            }
        }
    }
