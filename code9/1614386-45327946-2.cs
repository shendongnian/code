    System.Resources.ResourceManager rm = typeof(AppResources)
                .GetRuntimeFields()
                .First(m => m.Name == "resourceMan")
                .GetValue(typeof(AppResources)) as System.Resources.ResourceManager;
    //or this variant
    var rm = new System.Resources.ResourceManager(typeof(AppResources));
    //CultureInfo culture 
    ResourceSet rs = rm.GetResourceSet(culture, true, false); 
    var nameItem = rs.OfType<DictionaryEntry>().FirstOrDefault(i => i.Value == "YourValue"); 
    var name = nameItem.Key.ToString();
