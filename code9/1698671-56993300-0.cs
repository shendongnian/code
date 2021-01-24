public class LocalizableValidationMetadataProvider : IValidationMetadataProvider
    {
        private IStringLocalizer _stringLocalizer;
        public LocalizableValidationMetadataProvider(IStringLocalizer stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
        }
        public void CreateValidationMetadata(ValidationMetadataProviderContext context)
        {
            // In the code below I assume that expected use of ErrorMessage will be:
            // 1 - not set when it is ok to fill with the default translation from the resource file
            // 2 - set to a specific key in the resources file to override my defaults
            // 3 - never set to a final text value
            foreach (var attribute in context.ValidationMetadata.ValidatorMetadata)
            {
                ValidationAttribute tAttr = attribute as ValidationAttribute;
                if (tAttr != null)
                {
                    var defaultName = tAttr.GetType().Name + "_ValidationError";
                    // Will look for resource keys like
                    // MaxLengthAttribute_ValidationError
                    // RangeAttribute_ValidationError
                    // EmailAddressAttribute_ValidationError
                    // RequiredAttribute_ValidationError
                    // etc.
                    // Treat errormessage as resource name, if it's set,
                    // otherwise assume default.
                    var name = tAttr.ErrorMessage ?? defaultName;
                    var localized = _stringLocalizer[name];
                    // Some attributes come with texts already preset (breaking the rule 3), 
                    // even if we didn't do that explicitly on the attribute.
                    // For example [EmailAddress] has entire message already filled in by MVC.
                    // Therefore we first check if we could find the value by the given key;
                    // if not, then fall back to default name.
                    if (localized.ResourceNotFound) // missing key or prefilled text
                        localized = _stringLocalizer[defaultName];
                    tAttr.ErrorMessage = localized;
                }
            }
        }
    }
    public static class LocalizedModelBindingMessageExtensions
    {
        public static IMvcBuilder AddModelBindingMessagesLocalizer(this IMvcBuilder mvc, IServiceCollection services)
        {
            var factory = services.BuildServiceProvider().GetService<IStringLocalizerFactory>();
            var stringLocalizer = factory.Create(typeof(ValidationMessagesResource));
            var L = stringLocalizer;
            return mvc.AddMvcOptions(o =>
            {
                // for attributes
                o.ModelMetadataDetailsProviders.Add(new LocalizableValidationMetadataProvider(stringLocalizer));
                // does not work for JSON models - Json.Net throws its own error messages into ModelState :(
                DefaultModelBindingMessageProvider provider = o.ModelBindingMessageProvider;
                provider.SetValueIsInvalidAccessor((v) => L["FormatHtmlGeneration_ValueIsInvalid", v]);
                provider.SetAttemptedValueIsInvalidAccessor((v, x) => L["FormatModelState_AttemptedValueIsInvalid", v, x]);
                provider.SetMissingBindRequiredValueAccessor((v) => L["FormatModelBinding_MissingBindRequiredMember", v]);
                provider.SetMissingKeyOrValueAccessor(() => L["FormatKeyValuePair_BothKeyAndValueMustBePresent" ]);
                provider.SetMissingRequestBodyRequiredValueAccessor(() => L["FormatModelBinding_MissingRequestBodyRequiredMember"]);
                provider.SetNonPropertyAttemptedValueIsInvalidAccessor((v) => L["FormatModelState_NonPropertyAttemptedValueIsInvalid", v]);
                provider.SetNonPropertyUnknownValueIsInvalidAccessor(() => L["FormatModelState_UnknownValueIsInvalid"]);
                provider.SetUnknownValueIsInvalidAccessor((v) => L["FormatModelState_NonPropertyUnknownValueIsInvalid", v]);
                provider.SetValueMustNotBeNullAccessor((v) => L["FormatModelBinding_NullValueNotValid", v]);
                provider.SetValueMustBeANumberAccessor((v) => L["FormatHtmlGeneration_ValueMustBeNumber", v]);
                provider.SetNonPropertyValueMustBeANumberAccessor(() => L["FormatHtmlGeneration_NonPropertyValueMustBeNumber"]);
                               
                // key names shamelessly stolen from ASP.NET Core source code
            });
        }
    }
In ConfigureServices in your Startup.cs file:
services.AddMvc( ... )
        .AddModelBindingMessagesLocalizer(services);
Create a folder Resources and put an empty class ValidationMessagesResource inside it.
Create ValidationMessagesResource.ab-CD.resx file (replace ab-CD with your desired culture).
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
