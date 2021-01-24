    HtmlDocument webDoc = new HtmlDocument();
    webDoc.LoadHtml(html);
    foreach (var table in webDoc.DocumentNode.SelectNodes("//table/tbody"))
    {
        foreach (var tr in table.SelectNodes("tr[position() > 1]"))
        {
            if (tr != null)
            {
                // [1] class name in HTML sample always the same
                var rateTwo = tr.SelectSingleNode("td[4]//span[@class='card_secondary_text']");
                Console.WriteLine("Method 1 Coupon: {0}",
                    rateTwo != null ? rateTwo.InnerText : "none"
                );
    
                // [2] brute force - all descendants
                var rateTwo2 = tr.SelectSingleNode("td[4]").Descendants();
                if (rateTwo2.Count() > 0)
                {
                    foreach (var child in rateTwo2)
                    {
                        if (child.InnerText.StartsWith("$") && child.NodeType == HtmlNodeType.Element) 
                            Console.WriteLine("Method 2 Coupon: {0}", child.InnerText);
                    }
                }
                else 
                {
                    Console.WriteLine("Method 2: No coupon");
                }
            }
        }
    }
