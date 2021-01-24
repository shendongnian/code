    public partial class MainWindow : ModernWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            var frame = Template.FindName("ContentFrame", this) as ModernFrame;
            if(frame != null)
                frame.CommandBindings.Add(new CommandBinding(FirstFloor.ModernUI.Windows.Navigation.LinkCommands.NavigateLink, OnNavigateLinkExecuted));
        }
        private void OnNavigateLinkExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if(e.Parameter == null)
            {
                ModernDialog dialog = new ModernDialog();
                dialog.ShowDialog();
            }
            else
            {
                OnNavigateLink(sender, e);
            }
        }
        private void OnNavigateLink(object sender, ExecutedRoutedEventArgs e)
        {
            if (LinkNavigator != null)
            {
                Uri uri;
                string parameter;
                string targetName;
                if (FirstFloor.ModernUI.Windows.Navigation.NavigationHelper.TryParseUriWithParameters(e.Parameter, out uri, out parameter, out targetName))
                    LinkNavigator.Navigate(uri, e.Source as FrameworkElement, parameter);
            }
        }
    }
