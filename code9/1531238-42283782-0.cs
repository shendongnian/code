    HtmlDocument html = new HtmlDocument();
                        html.LoadHtml(streamReader.ReadToEnd());
    
                        // ParseErrors is an ArrayList containing any errors from the Load statement
                        if (html.ParseErrors != null && html.ParseErrors.Count() > 0)
                        {
                            // Handle any parse errors as required
                        }
                        else
                        {
    
                            if (html.DocumentNode != null)
                            {
                                HtmlNode formNode = html.DocumentNode.SelectNodes("//form[@action]").FirstOrDefault();
    
                                if (formNode != null)
                                {
                                    HtmlAttribute att = formNode.Attributes["action"];
                                    if (att != null)
                                        _httpContext.Response.Redirect(att.Value);
                                    else
                                        _httpContext.Response.Redirect(storeLocation);
                                }
                            }
                        }
