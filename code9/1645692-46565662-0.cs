    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Controls.Primitives;
    using Windows.UI.Xaml.Data;
    using Windows.UI.Xaml.Input;
    using Windows.UI.Xaml.Media;
    using Windows.UI.Xaml.Navigation;
    using Windows.UI.Popups;
    namespace App1
    {
        /// <summary>   
        /// An empty page that can be used on its own or navigated to within a Frame.   
        /// </summary>   
        public sealed partial class MainPage : Page
        {
            public MainPage()
            {
                this.InitializeComponent();
            }
            private async void Button_Click(object sender, RoutedEventArgs e)
            {
                var dialog = new MessageDialog("Hi!");
                await dialog.ShowAsync();
            }
        }
    }
