    ResourceDictionary resourceDictionary = new ResourceDictionary
    {
         Source = new Uri("Dictionary1.xaml", UriKind.Relative)
    };
    
    ResourceDictionary resourceDictionary2 = new ResourceDictionary
    {
         Source = new Uri("Dictionary2.xaml", UriKind.Relative)
    };
    Application.Current.Resources.MergedDictionaries.Add(resourceDictionary );
    Application.Current.Resources.MergedDictionaries.Add(resourceDictionary2 );
