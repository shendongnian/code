    public class LocalizableValidationMetadataProvider : IValidationMetadataProvider
    {
        private IStringLocalizer _stringLocalizer;
        private Type _injectableType;
        public LocalizableValidationMetadataProvider(IStringLocalizer stringLocalizer, Type injectableType)
        {
            _stringLocalizer = stringLocalizer;
            _injectableType = injectableType;
        }
        public void CreateValidationMetadata(ValidationMetadataProviderContext context)
        {
            // ignore non-properties and types that do not match some model base type
            if (context.Key.ContainerType == null ||
                !_injectableType.IsAssignableFrom(context.Key.ContainerType))
                return;
            // In the code below I assume that expected use of ErrorMessage will be:
            // 1 - not set when it is ok to fill with the default translation from the resource file
            // 2 - set to a specific key in the resources file to override my defaults
            // 3 - never set to a final text value
            var propertyName = context.Key.Name;
            var modelName = context.Key.ContainerType.Name;
            // sanity check 
            if (string.IsNullOrEmpty(propertyName) || string.IsNullOrEmpty(modelName))
                return;
            foreach (var attribute in context.ValidationMetadata.ValidatorMetadata)
            {
                var tAttr = attribute as ValidationAttribute;
                if (tAttr != null)
                {               
                    // at first, assume the text to be generic error
                    var errorName = tAttr.GetType().Name;
                    var fallbackName = errorName + "_ValidationError";      
                    // Will look for generic widely known resource keys like
                    // MaxLengthAttribute_ValidationError
                    // RangeAttribute_ValidationError
                    // EmailAddressAttribute_ValidationError
                    // RequiredAttribute_ValidationError
                    // etc.
                    
                    // Treat errormessage as resource name, if it's set,
                    // otherwise assume default.
                    var name = tAttr.ErrorMessage ?? fallbackName;
                    // At first, attempt to retrieve model specific text
                    var localized = _stringLocalizer[name];
                    // Some attributes come with texts already preset (breaking the rule 3), 
                    // even if we didn't do that explicitly on the attribute.
                    // For example [EmailAddress] has entire message already filled in by MVC.
                    // Therefore we first check if we could find the value by the given key;
                    // if not, then fall back to default name.
                    // Final attempt - default name from property alone
                    if (localized.ResourceNotFound) // missing key or prefilled text
                        localized = _stringLocalizer[fallbackName];
                    // If not found yet, then give up, leave initially determined name as it is
                    var text = localized.ResourceNotFound ? name : localized;
                    tAttr.ErrorMessage = text;
                }
            }
        }
    }
    public class LocalizableInjectingDisplayNameProvider : IDisplayMetadataProvider
    {
        private IStringLocalizer _stringLocalizer;
        private Type _injectableType;
        public LocalizableInjectingDisplayNameProvider(IStringLocalizer stringLocalizer, Type injectableType)
        {
            _stringLocalizer = stringLocalizer;
            _injectableType = injectableType;
        }
        public void CreateDisplayMetadata(DisplayMetadataProviderContext context)
        {
            // ignore non-properties and types that do not match some model base type
            if (context.Key.ContainerType == null || 
                !_injectableType.IsAssignableFrom(context.Key.ContainerType))
                return;
            // In the code below I assume that expected use of field name will be:
            // 1 - [Display] or Name not set when it is ok to fill with the default translation from the resource file
            // 2 - [Display(Name = x)]set to a specific key in the resources file to override my defaults
            var propertyName = context.Key.Name;
            var modelName = context.Key.ContainerType.Name;
            // sanity check 
            if (string.IsNullOrEmpty(propertyName) || string.IsNullOrEmpty(modelName))
                return;
            
            var fallbackName = propertyName + "_FieldName";
            // If explicit name is missing, will try to fall back to generic widely known field name,
            // which should exist in resources (such as "Name_FieldName", "Id_FieldName", "Version_FieldName", "DateCreated_FieldName" ...)
            
            var name = fallbackName;
            // If Display attribute was given, use the last of it
            // to extract the name to use as resource key
            foreach (var attribute in context.PropertyAttributes)
            {
                var tAttr = attribute as DisplayAttribute;
                if (tAttr != null)
                {
                    // Treat Display.Name as resource name, if it's set,
                    // otherwise assume default. 
                    name = tAttr.Name ?? fallbackName;
                }
            }
            // At first, attempt to retrieve model specific text
            var localized = _stringLocalizer[name];
            // Final attempt - default name from property alone
            if (localized.ResourceNotFound)
                localized = _stringLocalizer[fallbackName];
            // If not found yet, then give up, leave initially determined name as it is
            var text = localized.ResourceNotFound ? name : localized;
            context.DisplayMetadata.DisplayName = () => text;
        }
    }
    public static class LocalizedModelBindingMessageExtensions
    {
        public static IMvcBuilder AddModelBindingMessagesLocalizer(this IMvcBuilder mvc,
            IServiceCollection services, Type modelBaseType)
        {
            var factory = services.BuildServiceProvider().GetService<IStringLocalizerFactory>();
            var VL = factory.Create(typeof(ValidationMessagesResource));
            var DL = factory.Create(typeof(FieldNamesResource));
            return mvc.AddMvcOptions(o =>
            {
                // for validation error messages
                o.ModelMetadataDetailsProviders.Add(new LocalizableValidationMetadataProvider(VL, modelBaseType));
                // for field names
                o.ModelMetadataDetailsProviders.Add(new LocalizableInjectingDisplayNameProvider(DL, modelBaseType));
                // does not work for JSON models - Json.Net throws its own error messages into ModelState :(
                // ModelBindingMessageProvider is only for FromForm
                // Json works for FromBody and needs a separate format interceptor
                DefaultModelBindingMessageProvider provider = o.ModelBindingMessageProvider;
                provider.SetValueIsInvalidAccessor((v) => VL["FormatHtmlGeneration_ValueIsInvalid", v]);
                provider.SetAttemptedValueIsInvalidAccessor((v, x) => VL["FormatModelState_AttemptedValueIsInvalid", v, x]);
                provider.SetMissingBindRequiredValueAccessor((v) => VL["FormatModelBinding_MissingBindRequiredMember", v]);
                provider.SetMissingKeyOrValueAccessor(() => VL["FormatKeyValuePair_BothKeyAndValueMustBePresent" ]);
                provider.SetMissingRequestBodyRequiredValueAccessor(() => VL["FormatModelBinding_MissingRequestBodyRequiredMember"]);
                provider.SetNonPropertyAttemptedValueIsInvalidAccessor((v) => VL["FormatModelState_NonPropertyAttemptedValueIsInvalid", v]);
                provider.SetNonPropertyUnknownValueIsInvalidAccessor(() => VL["FormatModelState_UnknownValueIsInvalid"]);
                provider.SetUnknownValueIsInvalidAccessor((v) => VL["FormatModelState_NonPropertyUnknownValueIsInvalid", v]);
                provider.SetValueMustNotBeNullAccessor((v) => VL["FormatModelBinding_NullValueNotValid", v]);
                provider.SetValueMustBeANumberAccessor((v) => VL["FormatHtmlGeneration_ValueMustBeNumber", v]);
                provider.SetNonPropertyValueMustBeANumberAccessor(() => VL["FormatHtmlGeneration_NonPropertyValueMustBeNumber"]);
            });
        }
    }
In ConfigureServices in your Startup.cs file:
services.AddMvc( ... )
            .AddModelBindingMessagesLocalizer(services, typeof(IDtoModel));
I have used my custom empty `IDtoModel` interface here and applied it to all my API models that will need the automatic localization for errors and field names.
Create a folder Resources and put empty classes ValidationMessagesResource and FieldNamesResource inside it.
Create ValidationMessagesResource.ab-CD.resx and FieldNamesResource .ab-CD.resx files (replace ab-CD with your desired culture).
Fill in the values for the keys you need, e.g. `FormatModelBinding_MissingBindRequiredMember`, `MaxLengthAttribute_ValidationError` ...
When launching the API from a browser, make sure to modify `accept-languages` header to be your culture name, otherwise Core will use it instead of defaults. For API that needs single language only, I prefer to disable culture providers altogether using the following code:
private readonly CultureInfo[] _supportedCultures = new[] {
                            new CultureInfo("ab-CD")
                        };
...
var ci = new CultureInfo("ab-CD");
// can customize decimal separator to match your needs - some customers require to go against culture defaults and, for example, use . instead of , as decimal separator or use different date format
/*
  ci.NumberFormat.NumberDecimalSeparator = ".";
  ci.NumberFormat.CurrencyDecimalSeparator = ".";
*/
_defaultRequestCulture = new RequestCulture(ci, ci);
...
services.Configure<RequestLocalizationOptions>(options =>
            {
                options.DefaultRequestCulture = _defaultRequestCulture;
                options.SupportedCultures = _supportedCultures;
                options.SupportedUICultures = _supportedCultures;
                options.RequestCultureProviders = new List<IRequestCultureProvider>(); // empty list - use default value always
            });
