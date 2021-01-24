    using System.Windows.Forms;
    using CefSharp;
    using CefSharp.WinForms;
    
    namespace WindowsFormsApp2
    {
        public partial class Form1 : Form
        {
            ChromiumWebBrowser chrome;
    
            private void InitChrome()
            {
                CefSettings settings = new CefSettings();
                Cef.Initialize(settings);
                chrome = new ChromiumWebBrowser("https://www.youtube.com/embed/v2fDTOdWuQQ?rel=0&amp;showinfo=0");
                this.Controls.Add(chrome);
                chrome.Dock = DockStyle.Fill;
            }
            public Form1()
            {
                InitializeComponent();
                InitChrome();
                //this.webBrowser1.Navigate("https://www.youtube.com/embed/v2fDTOdWuQQ?rel=0&amp;showinfo=0");
            }
    
        }
    }
