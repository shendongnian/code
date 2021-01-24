    using DotNetBrowser;
    using DotNetBrowser.WinForms;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Text;
    using System.Windows.Forms;
    namespace GetAjaxResponseBodySample
    {
        public partial class Form1 : Form
        {
            private static List<string> ajaxUrls = new List<string>();
            private WinFormsBrowserView browserView;
    
            public Form1()
            {
                InitializeComponent();
                browserView = new WinFormsBrowserView();
                browserView.Browser.Context.NetworkService.ResourceHandler = new AjaxResourceHandler();
                browserView.Browser.Context.NetworkService.NetworkDelegate = new AjaxNetworkDelegate();
                Controls.Add(browserView);
                browserView.Browser.LoadURL("http://www.w3schools.com/xml/ajax_examples.asp");
            }
    
            private class AjaxResourceHandler : ResourceHandler
            {
                public bool CanLoadResource(ResourceParams parameters)
                {
                    if (parameters.ResourceType == ResourceType.XHR)
                    {
                        Debug.WriteLine("Intercepted AJAX request: " + parameters.URL);
                        ajaxUrls.Add(parameters.URL);
                    }
                    return true;
                }
            }
    
            private class AjaxNetworkDelegate : DefaultNetworkDelegate
            {
                public override void OnDataReceived(DataReceivedParams parameters)
                {
                    if (ajaxUrls.Contains(parameters.Url))
                    {
                        Debug.WriteLine("Captured response for: " + parameters.Url);
                        Debug.WriteLine("MimeType = " + parameters.MimeType);
                        Debug.WriteLine("Charset = " + parameters.Charset);
                        PrintResponseData(parameters.Data);
                    }
                }
    
                private void PrintResponseData(byte[] data) {
                    Debug.WriteLine("Data = ");
                    var str = Encoding.Default.GetString(data);
                    Debug.WriteLine(str);
                }
            }
        }
    }
