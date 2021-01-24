    foreach (var box in doc.DocumentNode.SelectNodes("//*[@id=\"content\"]/div/div/div/div"))
                {
           
                    var singleBoxTitle = box.SelectSingleNode(".//*[contains(@class,'feed_title')]/h2/a");
                    
                    var singleBoxArticles = box.SelectNodes(".//*[contains(@class,'newsbox_inner')]");
                    if(singleBoxArticles != null)
                    {
                        foreach (var singleArticle in singleBoxArticles)
                        {
                            var singlefoundArticle = singleArticle.SelectSingleNode(".//div");
                            if (singlefoundArticle != null)
                            {
                                foreach (var partOfSomething in singlefoundArticle.SelectNodes(".//div/a"))
                                {
                                    if (singlefoundArticle != null)
                                    {
                                        
                                    }
                                        
                                }
                                    
                            }
                            
                        }
                    }
                }
