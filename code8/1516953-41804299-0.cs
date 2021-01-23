        private void Form1_Load(object sender, EventArgs e)
        {
            webBrowser1.Navigate("http://www.google.com");
        }
        private void button2_Click(object sender, EventArgs e)
        {
            IHTMLDocument2 doc = (IHTMLDocument2)webBrowser1.Document.DomDocument;
            IHTMLControlRange imgRange = (IHTMLControlRange)((HTMLBody)doc.body).createControlRange();
            foreach (IHTMLImgElement img in doc.images)
            {
                imgRange.add((IHTMLControlElement)img);
                imgRange.execCommand("Copy", false, null);
                using (Bitmap bmp = (Bitmap)Clipboard.GetDataObject().GetData(DataFormats.Bitmap))
                {
                    bmp.Save(@"C:\" + img.nameProp);
                }
            }
        }
