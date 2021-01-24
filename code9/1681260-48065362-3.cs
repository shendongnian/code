    using System;
    using System.Windows.Forms;
    namespace winforms
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                webBrowser1.Navigate(new Uri("http://www.google.com"));
                webBrowser1.DocumentCompleted += WebBrowser1_DocumentCompleted;
            }
            private void WebBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
            {
                var browser = webBrowser1.ActiveXInstance as SHDocVw.InternetExplorer;
                browser.ExecWB(SHDocVw.OLECMDID.OLECMDID_OPTICAL_ZOOM, SHDocVw.OLECMDEXECOPT.OLECMDEXECOPT_DODEFAULT,200 ,IntPtr.Zero );
            }
        }
    }
