    public sealed partial class MainPage : Page
    {
        HyperlinkButton hLinkButton = new HyperlinkButton();
        public MainPage()
        {
            this.InitializeComponent();
           
            hLinkButton.Name = "LearnMoreHyperLink";
            hLinkButton.Content = "Learn More...";
            hLinkButton.Background = new SolidColorBrush(Colors.Red);
            hLinkButton.Foreground = new SolidColorBrush(Colors.White);
            hLinkButton.FontWeight = FontWeights.SemiBold;
            hLinkButton.FontSize = 18.0;
            hLinkButton.PointerEntered += OnPointerEntered;
            LayoutGrid.Children.Add(hLinkButton);
        }      
        private void OnPointerEntered(object sender, PointerRoutedEventArgs e)
        {
            hLinkButton.Background = new SolidColorBrush(Colors.White);
            hLinkButton.Foreground = new SolidColorBrush(Colors.Red);
            hLinkButton.FontSize = 30.0;
        }
    }
