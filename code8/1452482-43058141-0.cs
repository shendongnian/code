    public class CustomBootstrapper : BootstrapperApplication
    {
        protected override void Run()
        {
            if (Application.Current == null)
            {
                new Application();
            }
            if (Application.ResourceAssembly == null)
            {
                var assembly = typeof(CustomBootstrapper).Assembly;
                Application.ResourceAssembly = assembly;
            }
            var myStyle = (ResourceDictionary)Application.LoadComponent(new Uri("/styling/MyStyle.xaml", UriKind.Relative));
            Application.Current.Resources.MergedDictionaries.Add(myStyle);
            var view = new MainWindow();
            view.Show();
        }
    }
