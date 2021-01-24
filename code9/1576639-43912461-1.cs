    public class TextBoxTypeExtension:MarkupExtension
        {
            private readonly Binding _binding;
            public TextBoxTypeExtension(Binding binding,Enums.FieldType type)
            {
                _binding = binding;
                _binding.Converter = new NumberConverter();
                _binding.ConverterParameter = type;
            }
            public override object ProvideValue(IServiceProvider serviceProvider)
            {
                return _binding.ProvideValue(serviceProvider);
            }
        }
