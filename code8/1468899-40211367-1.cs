    public class StyleRefExt : StyleRefExtension
    {
        static StyleRefExt()
        {
            RD = new ResourceDictionary
                 {
                     Source = new Uri("pack://application:,,,/##YOUR_ASSEMBLYNAME##;component/Styles/##YOUR_RESOURCE_DICTIONARY_FILE##.xaml")
                 };
        }
    }
