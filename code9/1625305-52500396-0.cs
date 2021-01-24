    public class NameOfExtension : MarkupExtension
    {
        private readonly PropertyPath propertyPath;
        public NameOfExtension(Binding binding)
        {
            propertyPath = binding.Path;
        }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            var indexOfLastVariableName = propertyPath.Path.LastIndexOf('.');
            return propertyPath.Path.Substring(indexOfLastVariableName + 1);
        }
    }
