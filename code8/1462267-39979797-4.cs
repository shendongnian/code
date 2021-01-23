    public class LocalResourceDictionary : ResourceDictionary
    {
        public LocalResourceDictionary()
        {
            Source = new Uri("Resources.xaml", UriKind.Relative);
        }
    }
