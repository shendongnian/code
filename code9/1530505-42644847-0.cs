    var links = webBrowser1.Document.GetElementsByTagName("div");
                    foreach (HtmlElement link in links)
                    {  
                        if(link !=null)
                        {
                            
                            if (link.GetAttribute("ng-click").Equals("vmFASummary.navigateToDetails(summaryRow)"))
                            {
    
                                link.InvokeMember("Click");
                            }  
                        }
                    }
