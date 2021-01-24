    int Swipers = 0;
                HtmlWeb _Web = new HtmlWeb();
                HtmlAgilityPack.HtmlDocument htmldoc = _Web.Load(Url);
                htmldoc.OptionFixNestedTags = true;
                try
                {
                    foreach (HtmlNode x in htmldoc.DocumentNode.SelectNodes(@"//article[@data-name]"))
                    {
                        // var op = x.SelectSingleNode("./data-name");
                        //  var op = x.SelectNodes("div[@class='data-name']");
                        string result = x.GetAttributeValue("data-name", "null").ToLower();
    
    
                        if (result.Contains("thor"))
                        {
                           // System.Diagnostics.Process.Start(Url);
                            MessageBox.Show("It Appears!");
                            sendEmail();
                        }
                        Console.WriteLine(result);
                        Swipers++;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Cant get info!");
                }
    
