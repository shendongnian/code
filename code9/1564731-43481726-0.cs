            using (var client = new WebClient())
            {
                var content = client.DownloadString("http://www3.nhk.or.jp/news/");
                var doc = new HtmlDocument();
                doc.LoadHtml(content);
                var metaDescNode = doc.DocumentNode.SelectSingleNode("//meta[@name=\"description\"]"); // OuterHTML here looks like ã\u0081®ãƒ‹ãƒ¥ãƒ¼ã‚¹ã‚µã‚¤ãƒˆã€Œ
                var bytes = Encoding.Default.GetBytes(metaDescNode.Attributes["content"].Value);
                var decodedMetaDesc = Encoding.UTF8.GetString(bytes); // This string has decoded characters - see screenshot
                Console.WriteLine(decodedMetaDesc); // This outputs ?????? since my Windows is not set to Japanese locale
                File.WriteAllText(@"C:\temp\decoded.txt", decodedMetaDesc);
            }
