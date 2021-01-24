        string wallFolderPath = Server.MapPath("~/assets/wall/");
                    var newGuid = Guid.NewGuid().ToString();
                    string filename = wallFolderPath + "wallview_" + newGuid + ".xml";
                    var pathlocal = ServerUrlPath + "assets/wall/" + "wallview_" + newGuid + ".xml";
                    ViewBag.wallpath = pathlocal;
                    System.IO.File.Create(filename).Dispose();
        
        
                    List<propertyfile> data = ws.GetPropertyFiles();
                    XmlDocument writer = new XmlDocument();
                    
                    
                    // Create XML declaration
                    XmlNode declaration = writer.CreateNode(XmlNodeType.XmlDeclaration, null, null);
                    writer.AppendChild(declaration);
        
        
             
    
       //add rss node over here
                XmlElement rssElement = writer.CreateElement("rss");
                rssElement.SetAttribute("version", "2.0");
                rssElement.SetAttribute("xmlns:media", "http://search.yahoo.com/mrss/");
                rssElement.SetAttribute("xmlns:atom", "http://www.w3.org/2005/Atom");
        
                    
                    // Make the root element first
                    XmlElement channelElement = writer.CreateElement("Channel");
        
                    foreach (var a in data)
                    {
                        if (a.Path != null && a.ThumbnailPath != null)
                        {
                            XmlElement id = writer.CreateElement("item");
                            XmlElement name = writer.CreateElement("title");
                            name.InnerText = a.Name;
                            XmlElement age = writer.CreateElement("media:description");
                            var e_path = a.Path;
                            XmlElement anchor = writer.CreateElement("a");
                            e_path = e_path.Substring(2, e_path.Length - 2);
                            e_path = ServerUrlPath + e_path;
                            anchor.SetAttribute("href", e_path);
                            age.AppendChild(anchor);
                            //age.SetAttribute("href", e_path);
                            XmlElement linq = writer.CreateElement("link");
                            var e_linq = a.Path;
                            e_linq = e_linq.Substring(2, e_linq.Length - 2);
                            linq.InnerText = ServerUrlPath + e_linq;
                            XmlElement thumb = writer.CreateElement("media:thumbnail");
                            var e_thumbnail = a.ThumbnailPath;
                            e_thumbnail = e_thumbnail.Substring(2, e_thumbnail.Length - 2);
                            e_thumbnail = ServerUrlPath + e_thumbnail;
                            thumb.SetAttribute("url", e_thumbnail);
                            XmlElement content = writer.CreateElement("media:content");
                            content.SetAttribute("url", e_thumbnail);
                            id.AppendChild(name);
                            id.AppendChild(age);
                            id.AppendChild(linq);
                            id.AppendChild(thumb);
                            id.AppendChild(content);
                            channelElement.AppendChild(id);
                        }
                    }
        
                    
                    // chennel tag tto rss tag
                    rssElement.AppendChild(channelElement);
        
                    writer.Save(filename);
