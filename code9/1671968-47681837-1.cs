    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
        private void Button1_OnClick(object sender, RoutedEventArgs e)
        {
            ButtonHandlers.Handle(sender, e);
        }
        private void Button2_OnClick(object sender, RoutedEventArgs e)
        {
            ButtonHandlers.Handle(sender, e);
        }
        private void Button3_OnClick(object sender, RoutedEventArgs e)
        {
            ButtonHandlers.Handle(sender, e);
        }
    }
    internal static class ButtonHandlers
    {
        public static void Handle(object sender, RoutedEventArgs routedEventArgs)
        {
            // This is shared!
        }
    }
