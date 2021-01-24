    public class TranslateMarkupExtension : MarkupExtension
    {
        [ConstructorArgument("value1")]
        public string Value1 { get; set; }
        public TranslateMarkupExtension() { }
        public TranslateMarkupExtension(string value1)
        {
            Value1 = value1;
        }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            var rootObjectProvider = serviceProvider.GetService(typeof(IRootObjectProvider)) as IRootObjectProvider;
            var root = rootObjectProvider.RootObject;
            var translation = GetLangTranslator(root);
            return string.IsNullOrEmpty(translation) ? Value1 :translation;
        }
        private string GetLangTranslator(object root)
        {
            var properties = root.GetType().GetProperties();
            foreach (var property in properties)
            {
                if (typeof(MultiLanguage) == property.PropertyType)
                {                   
                    var m = property.PropertyType.GetMethod("Translate");
                    var propValue = property.GetValue(root);
                    return m.Invoke(propValue, new object[] {Value1}) as string;
                }
            }
            return null;
        }
    }
