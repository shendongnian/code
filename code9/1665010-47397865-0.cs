        public static void Main(string[] args)
        {
            HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://www.manualslib.com/brand/A.html");
                request.Method = "GET";
                request.ContentType = "text/html;charset=utf-8";
                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    using (var stream = response.GetResponseStream())
                    {
                        doc.Load(stream, Encoding.GetEncoding("utf-8"));
                    }
                }
            }
            catch (WebException ex)
            {
                Console.WriteLine(ex.Message);
            }
            //Works fine
            HtmlNode tablebody = doc.DocumentNode.SelectSingleNode("//table[contains(@class, 'table')]/tbody");
            foreach(HtmlNode tr in tablebody.SelectNodes("./tr"))
            {
                Console.WriteLine("\nTableRow: ");
                foreach(HtmlNode td in tr.SelectNodes("./td"))
                {
                    if (td.GetAttributeValue("class", "null") == "col1")
                    {
                        Console.Write("\t " + td.InnerText);
                    }
                    else
                    {
                        HtmlNode temp = td.SelectSingleNode(".//div[@class='catel']/a");
                        if (temp != null)
                        {
                            Console.Write("\t " + temp.GetAttributeValue("href", "no url"));
                        }
                    }
                }
            }
            Console.ReadKey();
        }
