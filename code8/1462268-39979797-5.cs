    public class LocalResourceDictionary : ResourceDictionary
    {
        public LocalResourceDictionary()
        {
            Source = new Uri("pack://application:,,,/MyAssemblyName;component/Resourc‌​es.xaml", UriKind.Absolute);
        }
    }
    
