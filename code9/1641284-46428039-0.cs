    HtmlNode links = document.DocumentNode.SelectSingleNode("//*[@id='navigation']/div/ul");
        foreach (HtmlNode urls in document.DocumentNode.SelectNodes("//a[@]"))
            {
               var temp = catagory.Attributes["href"].Value;
               if (temp.Contains("some_word"))
                  {
                    dgv.Rows.Add(temp);
                  }
            }
