    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US"); ;
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US"); ;
            FrameworkElement.LanguageProperty.OverrideMetadata(
              typeof(FrameworkElement),
              new FrameworkPropertyMetadata(
                    XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag)));
            base.OnStartup(e);
        }
    }
