            string htmlCode = "";
            using (WebClient client = new WebClient())
            {
                client.Headers.Add(HttpRequestHeader.UserAgent, "AvoidError");
                htmlCode = client.DownloadString("http://www.sismologia.cl/links/ultimos_sismos.html");
            }
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(htmlCode);
            var dt = new DataTable();
            dt.Columns.Add("Local", typeof(string));
            dt.Columns.Add("UTC", typeof(string));
            foreach (var row in doc.DocumentNode.SelectNodes("//*[@id='main']//tr"))
            {
                var nodes = row.SelectNodes("td");
                if (nodes != null)
                {
                    var local = nodes[0].InnerText;
                    var utc = nodes[1].InnerText;
                    dt.Rows.Add(local, utc);
                }
            }
