    namespace YourNamespace
    {
        
        public class MyCustomButton : Button
        {
            
            public MyCostumButton()
            {
                
                ResourceDictionary res = Application.LoadComponent(new Uri("/Directory/StyleDirectory.xaml", UriKind.RelativeOrAbsolute)) as ResourceDictionary;
                if (res == null)
                    return;
                Resources.MergedDictionaries.Add(res);
                Style = (Style)FindResource("Name of the x:Key your gave your style");
            }
        }
    }
