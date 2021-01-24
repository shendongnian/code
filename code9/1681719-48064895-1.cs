    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var culture = new CultureInfo("en");
            FrameworkElement.LanguageProperty.OverrideMetadata(typeof(FrameworkElement), 
                new FrameworkPropertyMetadata(XmlLanguage.GetLanguage(culture.IetfLanguageTag)));
        }
    }
