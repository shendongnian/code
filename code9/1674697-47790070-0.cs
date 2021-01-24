    public sealed partial class MainPage : Page
        {
            public MainPage()
            {
                this.InitializeComponent();
                this.SizeChanged += MainPage_SizeChanged;
            }
    
            private void MainPage_SizeChanged(object sender, SizeChangedEventArgs e)
            {
                var height = this.ActualHeight;
                var width = this.ActualWidth;
    
                btnTest.Margin = new Thickness(0, 0, 0.25 * width, 0.25 * height);
            }
        }
