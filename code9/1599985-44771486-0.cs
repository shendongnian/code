    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.webBrowser1.Navigated += WebBrowser1_Navigated;
        }
        private void WebBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            var doc = webBrowser1.Document;
            doc.InvokeScript("alert('hello')");
            var forms =doc.GetElementsByTagName("form");
            
        }
        private void btnGo_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate(txtUrl.Text);
            
        }
    }
