    var xmlText="<root>
    <location>
    <name>Kandy</name>
    <region>Central</region>
    <country>Sri Lanka</country>
    <lat>7.3</lat>
    <lon>80.64</lon>
    <tz_id>Asia/Colombo</tz_id>
    <localtime_epoch>1506414825</localtime_epoch>
    <localtime>2017-09-26 14:03</localtime>
    </location>
    </root>";
    XDocument xDocument = XDocument.Parse(xmlText);
    string region= xDocument.Root.Element("location").Element("region").Value;
    regionTextBox.Text=region;
   
     but it will be nice  solution to create model then you can use this snippet
            public T Deserialize<T>(string input) where T : class
            {
                System.Xml.Serialization.XmlSerializer ser = new System.Xml.Serialization.XmlSerializer(typeof(T));
    
                using (StringReader sr = new StringReader(input))
                {
                    return (T)ser.Deserialize(sr);
                }
            }
