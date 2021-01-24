    static void Main(string[] args)
            {
                string input = "<div class=\"class1\" title=\"myfirstClass\"><a href=\"link.php\">text I want read in C#<span class=\"order-level\"></span>";
                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(input);
                foreach (HtmlNode item in doc.DocumentNode.Descendants("div"))
                {
                    var link = item.Descendants("a").First();
                    var text = link.InnerText.Trim();
                    Console.Write(text);
                }
                Console.ReadKey();
            }
