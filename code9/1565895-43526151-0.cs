    foreach (HtmlNode node in html.DocumentNode.SelectNodes("//form[@id='_subcat_ids_']"))
    {
      //get the categories, store in list
      foreach (HtmlNode node2 in node.SelectNodes("..//a[@class='facet-selection  multiselect-facets ']//text()[normalize-space() and not(ancestor::span)]"))
      {
        string tempCat = node2.InnerText.Trim();
        categoryList.Add(tempCat);
        Console.Write("\nCategory: " + tempCat);           
      }
      foreach (HtmlNode node3 in node.SelectNodes("..//a[@class='facet-selection  multiselect-facets ']"))
      {
        //get href for each category, store in list
        string tempHref = node3.GetAttributeValue("href", string.Empty);
        LinkCatList.Add(tempHref);
        Console.Write("\nhref: " + tempHref);
        //get the number of items from categories, store in list
        string tempNum = node3.SelectSingleNode(".//span[@class='subtle-note']").InnerText.Trim();
        string tp = tempNum.Replace("(", "");
        tempNum = tp;
        tp = tempNum.Replace(")", "");
        tempNum = tp;
        Console.Write("\nNumber of items: " + tempNum + "\n\n");
       }
    }
