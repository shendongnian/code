    [ComVisible(true)]
    public class TestForm : Form
    {
        WebBrowser _WebBrowser = null;
        public TestForm()
        {
            _WebBrowser = new WebBrowser();
            this.Controls.Add(_WebBrowser);
            var imgurl = "https://www.google.com/images/branding/googlelogo/2x/googlelogo_color_120x44dp.png";
            _WebBrowser.DocumentCompleted += (s, e) =>
            {
                //add onclick event dynamically
                foreach (var img in _WebBrowser.Document.GetElementsByTagName("img")
                                    .OfType<HtmlElement>())
                {
                    img.AttachEventHandler("onclick", (_,__)=>OnClick(img));
                        
                }
            };
             
            //OR _WebBrowser.Navigate    
            _WebBrowser.DocumentText = $"<html>  <img src='{imgurl}' id=123 />  </html>";
        }
        void OnClick(HtmlElement img)
        {
            MessageBox.Show(img.GetAttribute("id"));
        }
    }
        
