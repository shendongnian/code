    [ContentProperty("Key")]
	public sealed class WordByKeyExtension : IMarkupExtension<BindingBase>
	{
        public string Key { get; set; }
        static IValueConverter converter = new TranslationWithKeyConverter();
        
        BindingBase IMarkupExtension<BindingBase>.ProvideValue(IServiceProvider serviceProvider)
		{
			return new Binding("Tanslations", BindingMode.OneWay, converter: converter, converterParameter: Key);
		}
        object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider)
		{
			return (this as IMarkupExtension<BindingBase>).ProvideValue(serviceProvider);
		}
    }
