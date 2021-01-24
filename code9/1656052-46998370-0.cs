    public sealed partial class MainPage : Page
    {
        public DataPageViewModel Model { get { return (DataPageViewModel)DataContext; } }
        public MainPage()
        {
            this.InitializeComponent();
            this.DataContext = new DataPageViewModel();
        }
        // I added this to your example so that I had a way to modify
        // the property and observe any binding updates
        private void button_Click(object sender, RoutedEventArgs e)
        {
            Model.FormItem.Value++;
        }
    }
