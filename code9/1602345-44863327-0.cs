    XmlDocument tournamentsXML = new XmlDocument();
                tournamentsXML.LoadXml(@"<root><source mount=""/AGMoffline"">
        <listeners>0</listeners>
        <listenurl>http:/X.X.X.X/AGMoffline</listenurl>
        <max_listeners>30</max_listeners>
    </source>
    <source mount=""/AGMoffline2"">
        <listeners>0</listeners>
        <listenurl> http://X.X.X.X/AGMoffline</listenurl>
        <max_listeners> 30</max_listeners >
    </source></root>");
                XmlNodeList nodes = tournamentsXML.DocumentElement.SelectNodes("//source[@mount='/AGMoffline2']");
    
                foreach (XmlNode node in nodes)
                {
                    //roll through node
                }
