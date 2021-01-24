    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            this.Resources.MergedDictionaries.Add(new ResourceDictionary() { Source = new Uri($"pack://application:,,,/MahApps.Metro;component/Styles/Accents/{Properties.settings.default}.xaml") });
        }
    }
