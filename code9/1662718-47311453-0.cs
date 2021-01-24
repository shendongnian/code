    public static void Main(string[] args)
    {
        HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
        try
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.yellowpages.ae/categories-by-alphabet/h.html");
            request.Method = "GET";
            request.ContentType = "text/html;charset=utf-8";
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
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
        Console.WriteLine(doc.DocumentNode.InnerHtml);
        Console.ReadKey();
    }
