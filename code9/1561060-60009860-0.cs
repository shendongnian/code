    public class EmbeddedSourceror
    {
        //NOTE: if there are resources *anywhere* with identical names, this will only return the *first* one it finds, so don't duplicate names
		public static Xamarin.Forms.ImageSource SourceFor(string filenameWithExtension)
        {       
            var resources = typeof(EmbeddedSourceror).GetTypeInfo().Assembly.GetManifestResourceNames();
            var resourceName = resources.First(r => r.EndsWith(filenameWithExtension, StringComparison.OrdinalIgnoreCase));
            return Xamarin.Forms.ImageSource.FromResource(resourceName);
		}
     }
