    public Dictionary<string,Bitmap> GetEmbeddedImages()
    {
        // Add a new Resources file named Resource1.resx; VS will generate a static class named Resource1
        // Add images to this file as required
        var assembly = System.Reflection.Assembly.GetExecutingAssembly();
        var resourceName = String.Format("{0}.{1}.resources", assembly.GetName().Name, typeof(Resource1).Name);
        Dictionary<string, Bitmap> images = new Dictionary<string, Bitmap>();
        
        using (var rStream = assembly.GetManifestResourceStream(resourceName))
        using (var rReader = new ResourceReader(rStream))
        {
            foreach (DictionaryEntry de in rReader)
            {
                var itemName = (string)de.Key;
                var itemValue = (Bitmap)de.Value;
                images.Add(itemName, itemValue);
            }
        }
        return images;
    }
