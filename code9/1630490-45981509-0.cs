    public ActionResult Index()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("Price");
    
        // Using HtmlAgilityPack Library
        HtmlDocument doc = new HtmlDocument();
    
        doc.Load("FILE_PATH_TO_YOUR_XML_FILE");
    
        // Get the XPath Value
        string xPath_Price = "price";
    
        // Now get all of the prices
    
        foreach (HtmlNode price in doc.DocumentNode.SelectNodes("//price"))
        {
             DataRow dr = dt.NewRow();
    
             dr["Price"] = price.SelectSingleNode(xPath_Price).InnerText;
             dt.Rows.Add(dr);
        }
    
        // Now Serialize this data and store it as a string
        // Use Newtonsoft.Json Library
        string all_prices = JsonConvert.SerializeObject(dt);
    
        // Now use this string and store it as a ViewBag Object to use in your View
    
        ViewBag.XPathPrices = all_prices;
    
        return View();
    
    }
