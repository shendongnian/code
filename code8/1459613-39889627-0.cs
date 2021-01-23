    string xml = @"<Root>
                   <Amount>
                       <Rate> INR to USD  3.0245</Rate>
                   </Amount>
                   <Amount>
                       <Rate> Dong to INR  5.201454</Rate>
                   </Amount>
                   </Root>";
    XDocument Doc = XDocument.Parse(xml);
    var list = Doc.Descendants("Rate")
                  .Select(y => Convert.ToDouble(Regex.Match(y.Value, @"\d+(?:\.\d+)?").Value))
                  .ToList();
