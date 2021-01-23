    try
    {
       var strXaml = File.ReadAllText( [your defaultTheme.xaml file] );    
       var dict = (ResourceDictionary)XamlReader.Parse(strXaml);
       YourWindow.Resources.MergedDictionaries.Add(dict);
    }
    catch
    {
       // error if invalid xaml / resource dictionary content
    }
