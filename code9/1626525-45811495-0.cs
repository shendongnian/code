      private void button1_Click(object sender, EventArgs e)
        {
            HtmlWeb web = new HtmlWeb();
            var doc = web.Load("http://localhost/site.html");
            HtmlNode rateNode = doc.DocumentNode.SelectSingleNode("//iframe[@id='test']");
            string rate = rateNode.InnerText;
        }
