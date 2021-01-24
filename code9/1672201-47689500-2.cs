        var result = document.DocumentNode.SelectNodes("//div//text()[normalize-space()] | //a");
    // select all textnodes and a tags
                string sch = "Scheduler link :";
                string dataLink = "Data path :";
                string linkpath = "Link :";
                foreach (var item in result)
                {
                    if (item.InnerText.Trim().Contains(sch))
                    {
                            var processResult = result.SkipWhile(x => !x.InnerText.Trim().Equals(sch)).Skip(1);
    // skip the result till we reache to Scheduler.
                            Debug.WriteLine("====================Scheduler link=========================");
                            foreach (var subitem in processResult)
                            {
                                Debug.WriteLine(subitem.GetAttributeValue("href", ""));
    // if href then add to list TODO
                                if (subitem.InnerText.Contains(dataLink)) // break when data link appears.
                                {
                                    break;
                                }
                            }
                        }
                        if (item.InnerText.Trim().Contains(dataLink))
                        {
                            var processResult = result.SkipWhile(x => !x.InnerText.Trim().Equals(dataLink)).Skip(1);
                            Debug.WriteLine("====================Data link=========================");
        
                            foreach (var subitem in processResult)
                            {
                                Debug.WriteLine(subitem.GetAttributeValue("href", ""));
                                if (subitem.InnerText.Contains(dataLink))
                                {
                                    break;
                                }
                            }
                        }
                        if (item.InnerText.Trim().Contains("Link :"))
                        {
                            var processResult = result.SkipWhile(x => !x.InnerText.Trim().Equals(linkpath)).Skip(1);
                            Debug.WriteLine("====================Link=========================");
                            foreach (var subitem in processResult)
                            {
                                var hrefValue = subitem.GetAttributeValue("href", "");
                                Debug.WriteLine(hrefValue);
                                if (subitem.InnerText.Contains(dataLink))
                                {
                                    break;
                                }
                            }
                        }
                    }
