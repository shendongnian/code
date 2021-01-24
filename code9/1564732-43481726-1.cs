            using (var client = new WebClient())
            {
                // UTF-8
                var content = client.DownloadString("http://www3.nhk.or.jp/news/");
                var doc = new HtmlDocument();
                doc.LoadHtml(content);
                var metaDescNode = doc.DocumentNode.SelectSingleNode("//meta[@name=\"description\"]");
                var bytes = Encoding.Default.GetBytes(metaDescNode.Attributes["content"].Value);
                var decodedMetaDesc = Encoding.UTF8.GetString(bytes); // This string has decoded characters
                // Shift_JIS
                var japaneseEncoding = Encoding.GetEncoding(932); 
                var content2 = client.DownloadString("http://www.toronto-electricians.com/");
                var doc2 = new HtmlDocument();
                doc2.LoadHtml(content2);
                var metaDescNode2 = doc2.DocumentNode.SelectSingleNode("//meta[@name=\"description\"]"); 
                var bytes2 = Encoding.Default.GetBytes(metaDescNode2.Attributes["content"].Value);
                var decodedMetaDesc2 = japaneseEncoding.GetString(bytes2); // This string has decoded characters
            }
