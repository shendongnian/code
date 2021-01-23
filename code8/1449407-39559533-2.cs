    public string GetData(string htmlContent)
    {
          HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();
          htmlDoc.OptionFixNestedTags = true;
          htmlDoc.LoadHtml(htmlContent);
          if (htmlDoc.DocumentNode != null)
          {
              string data = htmlDoc.DocumentNode.SelectNodes("//*[@id=\"main\"]/div[3]/div/div[2]/div[1]/div[1]/div/div/div[2]/a/span[1]")[0].InnerText;
              if(!string.IsNullOrEmpty(data))
                 return data;
          }
          return null;
    }
