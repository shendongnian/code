    namespace App1
    {
    [Preserve(AllMembers = true)]
    [ContentProperty("Source")]
    public class ImageResourceExtension : IMarkupExtension
    {
        public string Source { get; set; }
        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Source == null)
            {
                return null;
            }
            string s = Application.Current.Resources["logoEvo"] as string;
            // Do your translation lookup here, using whatever method you require
            var assembly = typeof(ImageResourceExtension).GetTypeInfo().Assembly;
            var assemblyString = assembly.GetName().Name.ToString();
            var imageSource = ImageSource.FromResource(assemblyString + "." + s);
            return imageSource;
        }
    }
    }
