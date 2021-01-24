    using System.Windows.Forms;
    namespace stackoverflow
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                webBrowser1.Navigate("http://www.google.com");
                webBrowser1.DocumentCompleted += WebBrowser1_DocumentCompleted;
            }
            private void WebBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
            {
                var FeelingLucky= webBrowser1.Document.GetElementById("gbqfbb");
                FeelingLucky.Style = "font-size: 40px;";
                var path = System.IO.Path.Combine(System.Environment.CurrentDirectory, "Stylesheet1.css");
                var StylesheetContent = System.IO.File.ReadAllText(path);
                var style= webBrowser1.Document.GetElementsByTagName("style")[0];
                style.InnerText = style.InnerText + " " + StylesheetContent;
            }
        }
    }
