    private static List<string> _InetReadEx(string sUrl)    // Returns string list
    {
        var aRet = new List<string>();                      // string list var
        try
        {
            var website = new HtmlAgilityPack.HtmlWeb();    // Init the object
            var htmlDoc = website.Load(sUrl);               // Load doc from URL
            var allElementsWithClassFloat = htmlDoc.DocumentNode.SelectNodes("//*[contains(@class,'pid')]"); // Get all nodes with class value containing pid
            if (allElementsWithClassFloat != null)          // If nodes found
            {
                for (int i = 0; i < allElementsWithClassFloat.Count; i++)
                {
                    if (!string.IsNullOrWhiteSpace(allElementsWithClassFloat[i].InnerText) && // if not blank/null
                        !aRet.Contains(allElementsWithClassFloat[i].InnerText)) // if not already present
                    {
                        aRet.Add(allElementsWithClassFloat[i].InnerText);  // Add to result
                        Console.WriteLine(allElementsWithClassFloat[i].InnerText); // Demo line
                    }
                }
            }
            return aRet;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
