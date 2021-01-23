    public class LocalResource : MarkupExtension
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return new ResourceDictionary() { 
                Source = new Uri("Resources.xaml", UriKind.Relative) 
            };
        }
    }
