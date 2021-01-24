    public MainWindow()
    {
        InitializeComponent();
        LoadTranslations();
    }
    
    private void LoadTranslations()
    {
        string file = GetTranslationsFileForSelectedLanguage();
    
        using (FileStream stream = File.OpenRead(file))
        {
            System.Windows.Markup.XamlReader reader = new System.Windows.Markup.XamlReader();
            ResourceDictionary myResourceDictionary = (ResourceDictionary)reader.LoadAsync(stream);
            Application.Current.Resources.MergedDictionaries.Add(myResourceDictionary);
        }
    }
    
    private string GetTranslationsFileForSelectedLanguage()
    {
        // todo: add selection logic for when we have more languages in the future
        return "ChineseTranslations.xaml";
    }
