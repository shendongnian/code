    // read a XML where a <resizer>...</resizer> is present, in this case a typical Web.config as mentioned in the ImageResizer docs
    var lWebConfigReader = new System.Xml.XmlTextReader(@"Web.config");
    var lXmlDocument = new System.Xml.XmlDocument();
    lXmlDocument.Load(lWebConfigReader);
    // read the resizer tag to a node
    var lResizerNode = lXmlDocument.SelectSingleNode("/configuration/resizer");
    // create a section from the node
    var lSection = new ImageResizer.ResizerSection(lResizerNode.OuterXml);
    // create a new config object from the section
    var lConfig = new ImageResizer.Configuration.Config(lSection);
    // override the global configugration with the newly created one
    ImageResizer.Configuration.Config.Current.setConfigXml(lConfig.getConfigXml());
    // test the Get() call used by the ClientCache plugin
    int mins = ImageResizer.Configuration.Config.Current.get("clientcache.minutes", -1);
