    var stream = "http://www.gamespot.com/feeds/news/";
    
                try
                {
                    var settings = new XmlReaderSettings()
                    {
                        ProhibitDtd = false,
                        IgnoreComments = true,
                        IgnoreWhitespace=true
                    };
    
                    string xml = new WebClient().DownloadString(stream);
    
                    XDocument doc = XDocument.Parse(xml);
                    doc.Descendants().Where(e => e.Name == "cache").Remove();
    
                    using (Stream memoryStream = new MemoryStream())  // Create a stream
                    {
                        doc.Save(memoryStream);      // Save XDocument into the stream
                        memoryStream.Position = 0;   // Rewind the stream ready to read from it elsewhere
    
                        using (XmlReader xmlReader = XmlReader.Create(memoryStream, settings))
                        {
                            xmlReader.Read();
    
                            var rss = new Rss20FeedFormatter();
                            var atom = new Atom10FeedFormatter();
                            var _feed = new SyndicationFeed();
                            // the problem is here when i try to load to  
                            // the feed with xmlReader, for some reason the 
                            //feed can't read the xmlReader. getting row and 
                            //position error.
                            if (atom.CanRead(xmlReader))
                            {
                                _feed = SyndicationFeed.Load(xmlReader);
                            }
                            else if (rss.CanRead(xmlReader))
                            {
                                _feed = SyndicationFeed.Load(xmlReader);
                            }
                            xmlReader.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    var message = ex.Message;
                }
