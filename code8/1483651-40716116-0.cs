    using System;
    using System.Linq;
    using System.Windows.Forms;
    using mshtml;
    
    // This code was written under the assumption that your form has a 
    // WebBrowser control named WebBrowser1, 
    // and that you have added the unmanaged MSHTML library as a reference to your project.
    
    namespace WebClientDemo
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                webBrowser1.Navigate(<your-url-here>);
            }
    
            private void webBrowser1_DocumentCompleted(object sender, 
                                              WebBrowserDocumentCompletedEventArgs e)
            {
                if (webBrowser1.Document == null)
                    return;
                IHTMLDocument2 iDoc = (IHTMLDocument2)webBrowser1.Document.DomDocument;
                HTMLSelectElement selectElement = iDoc?.all.OfType<HTMLSelectElement>()
                                       .FirstOrDefault(s => s.name == "birthday.month");
                if (selectElement != null)
                {
                    selectElement.selectedIndex = 2;
                }
            }
        }
    }
