     var html = new WebClient().DownloadString("mysite.com");
                HtmlDocument htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(html);
    
                var result = htmlDoc.DocumentNode.SelectNodes("//span[@class='mem_loc']").ElementAt(0).InnerText;
                var regionFullNames = CultureInfo
                           .GetCultures(CultureTypes.SpecificCultures)
                           .Select(x => new RegionInfo(x.LCID))
                           ;
                var twoLetterName = Regex.Replace(regionFullNames.FirstOrDefault(
                                       region => region.EnglishName.Contains(result)
                                    ).ToString(), "{.*?}","");
