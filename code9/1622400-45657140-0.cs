    ///Custom attribute
    [AttributeUsageAttribute(AttributeTargets.Property, AllowMultiple = false)]
    public class DisplayFormatAttribute : Attribute
    {
        public string DataFormatString { get; set; }
    }
    ///Custom markup extension
    [MarkupExtensionReturnType(typeof(object))]
    public class FormattedBindingExtension : MarkupExtension
    {
        public FormattedBindingExtension()
        {
        }
        public FormattedBindingExtension(PropertyPath path)
        {
            Path = path;
        }
        public IValueConverter Converter { get; set; }
        public object ConverterParamter { get; set; }
        [ConstructorArgument("path")]
        public PropertyPath Path { get; set; }
        [TypeConverter(typeof(CultureInfoIetfLanguageTagConverter))]
        public CultureInfo ConverterCulture { get; set; }
        private DependencyProperty _bindingTargetProperty;
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            var valueProvider = serviceProvider.GetService(typeof(IProvideValueTarget)) as IProvideValueTarget;
            if (valueProvider != null)
            {
                var bindingTarget = valueProvider.TargetObject as DependencyObject;
                var bindingTargetProperty = valueProvider.TargetProperty as DependencyProperty;
                if (bindingTargetProperty == null || bindingTarget == null || Path == null)
                {
                    throw new NotSupportedException(string.Format(
                        "The property '{0}' on target '{1}' is not valid for a FormattedBinding. The FormattedBinding target must be a DependencyObject, "
                        + "and the target property must be a DependencyProperty, and a Path must be specified.",
                        valueProvider.TargetProperty,
                        valueProvider.TargetObject));
                }
                
                // Add support so that the datacontext change causes an immediate commit with format
                var frameworkElement = bindingTarget as FrameworkElement;
                if (frameworkElement != null)
                {
                    frameworkElement.DataContextChanged += FrameworkElement_DataContextChanged;
                }
                _bindingTargetProperty = bindingTargetProperty;
                FrameworkElement_DataContextChanged(frameworkElement, new DependencyPropertyChangedEventArgs());
                
                // Return the current value of the binding (since it will have been evaluated because of the binding above)
                return bindingTarget.GetValue(bindingTargetProperty);
            }
            return null;
        }
        private void FrameworkElement_DataContextChanged(object sender, DependencyPropertyChangedEventArgs ignored)
        {
            var element = sender as FrameworkElement;
            if (element == null || element.DataContext == null)
                return;
            var propertyName = Path.Path;
            if (propertyName == null)
                return;
            var source = element.DataContext;
            var type = source.GetType();
            var property = type.GetProperty(propertyName);
            var format = property.GetCustomAttribute<DisplayFormatAttribute>()?.DataFormatString;
            Binding binding = GetBinding(format);
            // Apply and evaluate the binding
            var bindingExpression = BindingOperations.SetBinding(element, _bindingTargetProperty, binding);
            bindingExpression.UpdateTarget();
        }
        private Binding GetBinding(string format)
        {
            var binding = new Binding();
            binding.Path = Path;
            binding.Converter = Converter;
            binding.ConverterCulture = ConverterCulture;
            binding.ConverterParameter = ConverterParamter;
            binding.StringFormat = format;
            return binding;
        }
    }
