    [ContentProperty ("Source")]
	public class ImageResourceExtension : IMarkupExtension
	{
		public string Source { get; set; }
		public object ProvideValue (IServiceProvider serviceProvider)
		{
			if (Source == null)
				return null;
            var imageSource = new StreamImageSource { Stream = async (ct) => this.GetType().GetTypeInfo().Assembly.GetManifestResourceStream(Source) }; 
			return imageSource;
		}
	}
