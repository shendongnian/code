            Uri url = new Uri("http://www.milliyet.com.tr/sondakika/");
            WebClient client = new WebClient();
            client.Encoding = System.Text.Encoding.UTF8;
            var html = client.DownloadString(url);
            HtmlAgilityPack.HtmlDocument dokuman = new HtmlAgilityPack.HtmlDocument();
            dokuman.LoadHtml(html);
            IEnumerable<HtmlNode> htmlNodes = dokuman.DocumentNode.Descendants("ul").Where(d => d.Attributes.Contains("class") && d.Attributes["class"].Value.Contains("sonDK"));
            foreach (HtmlNode htmlNode in htmlNodes)
            {
                IEnumerable<HtmlNode> liList = htmlNode.Descendants("li").Where(l => (l.Attributes.Contains("class") && l.Attributes["class"].Value.Contains("title")) == false);
                foreach (HtmlNode liNode in liList)
                {
                    Console.WriteLine("strong:" + liNode.FirstChild.InnerText + "- link:" + liNode.LastChild.Attributes["href"].Value);
                }
            }
