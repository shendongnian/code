    public partial class Form1 : Form
    {
        private static bool _isDocumentLoaded;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            webBrowser1.DocumentCompleted += WebBrowserDocumentCompleted;
            webBrowser1.Navigate("www.google.dk");
        }
        private void WebBrowserDocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (webBrowser1.ReadyState != WebBrowserReadyState.Complete)
                return;
            _isDocumentLoaded = true;
            MessageBox.Show("Webpage loaded successfully");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(_isDocumentLoaded)
            {
                FillDocumentForms();
                Submit();
            } else {
                MessageBox.Show("Webpage is currently loading");,
            }
        }
        private void FillDocumentForms()
        {
            webBrowser1.Document..InvokeScript("eval", new[] { "document.getElementById(\"lst-ib\").innerText = \"Frederik\""});
            .....
        }
        private void Submit()
        {
            webBrowser1.Document.InvokeScript("eval", new[] { "document.getElementsByName(\"btnK\")[0].click()"});
        }
}
