    var newsource1= new Uri("pack://siteoforigin:,,,/resources/xxxx.xaml", UriKind.RelativeOrAbsolute);
    var newsource2= new Uri("pack://siteoforigin:,,,/resources/yyyyy.xaml", UriKind.RelativeOrAbsolute);
    Application.Current.Resources.MergedDictionaries.Remove(Appl‌​ication.Current.Reso‌​urces.MergedDictiona‌​ries[0]);
    Application.Current.Resources.MergedDictionaries.Remove(Appl‌​ication.Current.Reso‌​urces.MergedDictiona‌​ries[1]);
    
    Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary() { Source = newsource1});
    Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary() { Source = newsource2});
