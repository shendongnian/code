	//Load #1 ResourceDictionary
    ResourceDictionary resourceDictionary = new ResourceDictionary();
	resourceDictionary.Source = new Uri("Dictionary1.xaml", UriKind.Relative);
	
	//Load #2 ResourceDictionary
	ResourceDictionary resourceDictionary2 = new ResourceDictionary();
	resourceDictionary2.Source = new Uri("Dictionary2.xaml", UriKind.Relative);
	//Merge #1 & #2 
	resourceDictionary2.MergedDictionaries.Add(resourceDictionary);
	//Add to Resources
	Resources.MergedDictionaries.Add(resourceDictionary2);
