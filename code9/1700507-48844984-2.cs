    public partial class MainWindow : Window
    {
        public ObservableCollection<WebPageInfo> WebPageCollection { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            // Read tabs data from xml file
            //lst = ReadTabsFromXml();
            WebPageCollection = new ObservableCollection<WebPageInfo>();
            WebPageCollection.Add(new WebPageInfo() { Header = "Tab1", Uri = "https://www.amazon.com/" });
            WebPageCollection.Add(new WebPageInfo() { Header = "Tab2", Uri = "https://www.cnn.com/" });
            WebPageCollection.Add(new WebPageInfo() { Header = "Tab3", Uri = "https://www.microsoft.com/" });
            WebPageCollection.Add(new WebPageInfo() { Header = "Tab4", Uri = "https://www.facebook.com/" });
            MyTabControl.ItemsSource = WebPageCollection;
            MyTabControl.SelectedIndex = 0;
        }
        public class WebPageInfo
        {
            public string Header { get; set; }
            public string Uri { get; set; }
        }
    }
