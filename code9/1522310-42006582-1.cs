     public partial class Form1 : Form
     {
        Timer t;
        public Form1()
        {
            InitializeComponent();
            webBrowser1.DocumentCompleted += WebBrowser1_DocumentCompleted;
        }
        private void WebBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            WebBrowser wb = sender as WebBrowser;
            //check to make sure we are on the TOP-level page.
            if (wb.Document.Window.Parent == null)
            {
                t = new Timer();
                t.Tick += (Timersender, eventargs) =>
                {
                    //do whatever else you need to here
                    t.Stop();
                };
                t.Interval = 2000; //wait 2 seconds for the document to complete
                t.Start();
            }
        }
    }
