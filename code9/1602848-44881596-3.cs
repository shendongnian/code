    Dictionary<string, Image> dict = new Dictionary<string, Image>();
    var resourceManager = Resource1.ResourceManager;
    var resources = resourceManager.GetResourceSet(CultureInfo.CurrentCulture, true, true);
    foreach (DictionaryEntry item in resources)
    {
        if (item.Value is Bitmap)
        {
            dict.Add(item.Key as string, item.Value as Image);
        }
    }
