    public partial class Example : Page
    {
        public Example() {
            InitializeComponent();
            // In english
            this.Resources.MergedDictionaries.Add("en"));
            // In french
            //this.Resources.MergedDictionaries.Add("fr"));
        }
        public ResourceDictionary setLanguageDictionary(string language) {
            ResourceDictionary dict = new ResourceDictionary();
            switch (language) {
                case "en":
                    dict.Source = new Uri(AppDomain.CurrentDomain.BaseDirectory + "Resources\\StringResources.en-GB.xaml", UriKind.Absolute);
                    break;
                case "fr":
                    dict.Source = new Uri(AppDomain.CurrentDomain.BaseDirectory + "Resources\\StringResources.fr-FR.xaml",
                                       UriKind.Absolute);
                    break;
                default:
                    dict.Source = new Uri(AppDomain.CurrentDomain.BaseDirectory + "Resources\\StringResources.en-GB.xaml",
                                      UriKind.Absolute);
                    break;
            }
            return dict;
        }
    }
