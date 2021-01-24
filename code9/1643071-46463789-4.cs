    public partial class MainWindow : Window
    {
        private List<string> urls = new List<string>
            { "google.com", "microsoft.com", "teamdev.com", "teamdev.com/dotnetbrowser" };
        ManualResetEvent waitEvent = new ManualResetEvent(false);
        BrowserView webView = new WPFBrowserView();
        string path = "html.txt";
        public MainWindow()
        {
            InitializeComponent();
            mainLayout.Children.Add((UIElement)webView.GetComponent());
            webView.Browser.FinishLoadingFrameEvent += delegate (object sender, 
                FinishLoadingEventArgs e)
            {
                //System.Threading.Thread.Sleep(5000);
                if (e.IsMainFrame)
                {
                    DOMDocument document = e.Browser.GetDocument();
                    var html = document.DocumentElement.InnerHTML;
                    System.IO.File.WriteAllText(path, html);
                    waitEvent.Set();
                }
            };
            foreach (var url in urls)
            {
                Debug.WriteLine($"Loading {url}");
                webView.Browser.LoadURL(url);
                waitEvent.WaitOne();
                Debug.WriteLine($"{url} loaded");
                waitEvent.Reset();
            }
        }
    }
