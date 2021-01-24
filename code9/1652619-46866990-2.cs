    PropertyDescriptor siteProperty = null;
    PropertyDescriptor siteNameProperty = null;
    foreach (var item in items)
    {
        if (siteProperty == null) {
         PropertyDescriptorCollection itemProperties = TypeDescriptor.GetProperties(item);
            siteProperty = itemProperties["Site"];
        }
        object site = siteProperty.GetValue(item);
        if (siteNameProperty == null) {
         PropertyDescriptorCollection siteProperties = TypeDescriptor.GetProperties(site);
            siteNameProperty = siteProperties["SiteName"];
        }
        object siteName = siteNameProperty.GetValue(site);
        Console.WriteLine(siteName);
    }
