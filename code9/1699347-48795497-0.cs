    public static class EmbeddedResource
    {
        public static string[] GetApiRequestFile(string namespaceAndFileName)
        {
            try
            {
                using (var stream = typeof(EmbeddedResource).GetTypeInfo().Assembly.GetManifestResourceStream(namespaceAndFileName))
                using (var reader = new StreamReader(stream, Encoding.UTF8))
                    return reader.ReadToEnd().Split(';');
            }
            catch(Exception exception)
            {
                ApplicationProvider.WriteToLog<EmbeddedResource>().Error(exception.Message);
                throw new Exception($"Failed to read Embedded Resource {namespaceAndFileName}");
            }
        }
    }
