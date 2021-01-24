    // text xml
    var xml=@"<Data >
        <Inputs>
        <a:ImageInput>
            <a:Name>BSE</a:Name>
        </a:ImageInput>
        </Inputs>
         </Data>";
       
        XmlDocument xmld = new XmlDocument();
        
        XmlNamespaceManager nsmgr; // this will hold our namespaces with their prefixes
        xmld.Load(GetReader(xml, out nsmgr)); // xml can also be your file
       
        // we are going to find a text node, hence cast to XmlText
        var name2 = (XmlText)xmld.SelectSingleNode(
            "/Data/Inputs/a:ImageInput/a:Name[.='BSE']/text()", 
            nsmgr); // here is the namespace manager so it knows what a is
        if (name2 != null)
        {
            //name2.SetAttribute("a:Name", "{{16}}");
            name2.Value = "{{16}}";
        }
    
        string AmmendedFile = @"C:\ProgramData\Oxford Instruments NanoAnalysis\XXXX NewXMLReader\Xpath_Mics_Sim.xml";
        xmld.Save(AmmendedFile);
    }
    
    // Creates a reader and outputs a namespacemanager that fits for the missing namespace prefixes
    XmlReader GetReader(string xml, out XmlNamespaceManager nsmgr)
    {
        // code example taken from
        // https://blogs.msdn.microsoft.com/runeetv/2009/02/12/undeclared-namespace-in-xml-eg-xsi-is-an-undeclared-namespace/
        // from author runeetv and https://blogs.msdn.microsoft.com/runeetv/author/runeetvashisht/
        NameTable nt = new NameTable();
        // add missing namespace prefixes
        nsmgr = new XmlNamespaceManager(nt);
        nsmgr.AddNamespace("a", "urn:why-was-this-left-out?");
        XmlParserContext context = new XmlParserContext(null, nsmgr, null, XmlSpace.None);
        XmlReaderSettings xset = new XmlReaderSettings();
        xset.ConformanceLevel = ConformanceLevel.Fragment;
        
        // return XmlReader.Create(xml, xset, context); // use this if you want xml to be a filepath
        return XmlReader.Create(new  StringReader(xml), xset, context);
    }
