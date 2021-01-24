             FBCatalog.googleRss dataObject = new FBCatalog.googleRss();
             using (StringReader sReader = new StringReader(xml.InnerXml))
             {
                  sReader.ReadLine();
                  XmlReader reader = XmlReader.Create(sReader);
                  var serializer = new XmlSerializer(typeof(FBCatalog.googleRss), "rss");
              dataObject = (FBCatalog.googleRss)serializer.Deserialize(reader);
              GCatalog.Page page = new GCatalog.Page();
              counter = 0;
              foreach (var ITEM in dataObject.Channel.Items)
                   {
                       GCatalog.Item gItem = GCatalog.ConvertToGItem(ITEM);
                       page.Add(gItem);
                   }
            }
