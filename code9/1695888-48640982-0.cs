    public class StringToUriConverter : ITypeConverter<string, Uri>
    {
        public Uri Convert(string source, Uri destination, ResolutionContext context)
        {
            Uri.TryCreate(source, UriKind.Absolute, out destination);
    		return destination;
        }
    }
