    WebClient wc = new WebClient();
    wc.Proxy = null;
    wc.UseDefaultCredentials = true;
    string xml = wc.DownloadString(url);
    XDocument doc = XDocument.Parse(xml);
    MessageBox.Show(doc.FirstNode + "");
