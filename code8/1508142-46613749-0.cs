    public static class BindingObjectExtensions
    {
    public static Binding GetBinding(this BindableObject self, BindableProperty property)
            {
                if (self == null)
                {
                    throw new ArgumentNullException(nameof(self));
                }
                if (property == null)
                {
                    throw new ArgumentNullException(nameof(property));
                }
                var methodInfo = typeof(BindableObject).GetTypeInfo().GetDeclaredMethod("GetContext");
                var context = methodInfo?.Invoke(self, new object[] { property });
    
                var propertyInfo = context?.GetType().GetTypeInfo().GetDeclaredField("Binding");
                return propertyInfo?.GetValue(context) as Binding;
            }
    
    public static void SetCurrentValue(this BindableObject self, BindableProperty property, object value)
            {
                if (self == null)
                {
                    throw new ArgumentNullException(nameof(self));
                }
                if (property == null)
                {
                    throw new ArgumentNullException(nameof(property));
                }
                var backupBinding = self.GetBinding(property);//backup binding
                var backupConverter = backupBinding.Converter;//backup orig. converter
                self.SetValue(property,value);//removes the binding.
                backupBinding.Converter = new DefaultValueConverter {DefaultValue = value};//change the converter
                self.SetBinding(property, backupBinding);//target should be updated to the default value
                var converterField = backupBinding.GetType().GetTypeInfo().GetDeclaredField("_converter");
                converterField.SetValue(backupBinding, backupConverter);//restore the converter
            }
    }
    
    //the default value converter class
    
    [ContentProperty(nameof(DefaultValue))]
        public class DefaultValueConverter : BindableObject, IValueConverter, IMarkupExtension<DefaultValueConverter>
        {
            public object DefaultValue
            {
                get => GetValue(DefaultValueProperty);
                set => SetValue(DefaultValueProperty, value);
            }
    
            public static readonly BindableProperty DefaultValueProperty =
                BindableProperty.Create(nameof(DefaultValue), typeof(object), typeof(DefaultValueConverter));
    
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                return DefaultValue;
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                return DefaultValue;
            }
    
    
            public DefaultValueConverter ProvideValue(IServiceProvider serviceProvider)
            {
                return this;
            }
    
            object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider)
            {
                return ((IMarkupExtension<DefaultValueConverter>) this).ProvideValue(serviceProvider);
            }
        }
