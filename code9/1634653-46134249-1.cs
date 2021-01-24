    public class TestForm : Form
    {
        WebBrowser _WebBrowser = null;
        public TestForm()
        {
            _WebBrowser = new WebBrowser();
            _WebBrowser.ScriptErrorsSuppressed = true;
            _WebBrowser.Dock = DockStyle.Fill;
            this.Controls.Add(_WebBrowser);
            WebBrowserDocumentCompletedEventHandler Completed = null;
            Completed = (s, e) =>
            {
                //add onclick event dynamically
                foreach (var img in _WebBrowser.Document.GetElementsByTagName("img").OfType<HtmlElement>())
                {
                    img.AttachEventHandler("onclick", (_, __) => OnClick(img));
                }
                _WebBrowser.DocumentCompleted -= Completed;
            };
            _WebBrowser.DocumentCompleted += Completed;
            var imgurl = "https://www.google.com/images/branding/googlelogo/2x/googlelogo_color_120x44dp.png";
            //_WebBrowser.Navigate("http://edition.cnn.com/2017/09/09/us/hurricane-irma-cuba-florida/index.html");
            _WebBrowser.DocumentText = $"<html>  <img src='{imgurl}' id=123 />  </html>";
        }
        void OnClick(HtmlElement img)
        {
            MessageBox.Show(img.GetAttribute("id"));
        }
    }
        
