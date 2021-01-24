     class Program
    {
        private static WebBrowser wb1 = new WebBrowser();
        static void Main(string[] args)
        {
            wb1.Navigated += Wb1_Navigated;
            wb1.Navigate("www.mysite.it");
        }
        private static void Wb1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            //Retrieve string content of document
            var document = wb1.Document;
            var documentAsIHtmlDocument3 = (mshtml.IHTMLDocument3)document.DomDocument;
            var content = documentAsIHtmlDocument3.documentElement.innerHTML;
            //Parse content with html agility pack or whatever
            //Click on button
            wb1.Document.GetElementById("myId").InvokeMember("click");
        }
    }
