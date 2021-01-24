    public class SomeMvcOptionsSetup : Microsoft.Extensions.Options.IConfigureOptions<Microsoft.AspNetCore.Mvc.MvcOptions>
    {
        private readonly Microsoft.Extensions.Localization.IStringLocalizer _resourceLocalizer;
        public SomeMvcOptionsSetup()
        {
        }
        public SomeMvcOptionsSetup(Microsoft.Extensions.Localization.IStringLocalizerFactory stringLocalizerFactory)
        {
            _resourceLocalizer = stringLocalizerFactory.Create(baseName:"ResourceClassName",location:"ResourceNameSpace");
        }
        public void Configure(Microsoft.AspNetCore.Mvc.MvcOptions options)
        {
            options.ModelBindingMessageProvider.SetValueIsInvalidAccessor((x) =>
            {
                if (_resourceLocalizer == null)
                {
                    return "Custom Error Message";
                }
                return _resourceLocalizer["Specific Resource Key In Resource File"]; 
            });
            options.ModelBindingMessageProvider.SetValueMustNotBeNullAccessor((x) =>
            {
                if (_resourceLocalizer == null)
                {
                    return "Value Can not be null....";
                }
                return _resourceLocalizer["ResourceKeyValueCanNotBeNull"];
            });
      .
      .
      .
        }
    }
