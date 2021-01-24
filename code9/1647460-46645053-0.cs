        void Main()
    {
    	var rootelement = new XmlSerializer(typeof(Rootentity)).Deserialize(new MemoryStream(Encoding.UTF8.GetBytes(xmlText)));
    }
    
    // Define other methods and classes here
    
    [XmlRoot(ElementName = "rootentity")]
    public class Rootentity
    {
    	[XmlElement(ElementName = "cascadingentities")]
    	public Cascadingentities Cascadingentities { get; set; }
    	[XmlAttribute(AttributeName = "name")]
    	public string Name { get; set; }
    }
    
    [XmlRoot(ElementName = "cascadingentities")]
    public class Cascadingentities
    {
    	[XmlElement(ElementName = "cascadingentity")]
    	public Cascadingentity Cascadingentity { get; set; }
    }
    
    [XmlRoot(ElementName = "cascadingentity")]
    public class Cascadingentity
    {
    	[XmlElement(ElementName = "fetchXML")]
    	public FetchXML FetchXML { get; set; }
    	[XmlAttribute(AttributeName = "name")]
    	public string Name { get; set; }
    }
    
    [XmlRoot(ElementName = "fetchXML")]
    public class FetchXML
    {
    	[XmlElement(ElementName = "fetch")]
    	public Fetch Fetch { get; set; }
    }
    
    [XmlRoot(ElementName = "fetch")]
    public class Fetch
    {
    	[XmlElement(ElementName = "entity")]
    	public Entity Entity { get; set; }
    }
    
    [XmlRoot(ElementName = "entity")]
    public class Entity
    {
    	[XmlElement(ElementName = "attribute")]
    	public Attribute Attribute { get; set; }
    	[XmlElement(ElementName = "filter")]
    	public Filter Filter { get; set; }
    	[XmlAttribute(AttributeName = "name")]
    	public string Name { get; set; }
    }
    
    [XmlRoot(ElementName = "attribute")]
    public class Attribute
    {
    	[XmlAttribute(AttributeName = "name")]
    	public string Name { get; set; }
    }
    
    [XmlRoot(ElementName = "filter")]
    public class Filter
    {
    	[XmlElement(ElementName = "condition")]
    	public Condition Condition { get; set; }
    	[XmlAttribute(AttributeName = "type")]
    	public string Type { get; set; }
    }
    
    [XmlRoot(ElementName = "condition")]
    public class Condition
    {
    	[XmlAttribute(AttributeName = "attribute")]
    	public string Attribute { get; set; }
    	[XmlAttribute(AttributeName = "operator")]
    	public string Operator { get; set; }
    	[XmlAttribute(AttributeName = "value")]
    	public string Value { get; set; }
    }
    
    string xmlText = @"<rootentity name='xyz'>
    <cascadingentities>
        <cascadingentity name='xyz'>
            <fetchXML>
                <fetch>
                    <entity name='xyz' >
                        <attribute name='xyz' />
                        <filter type='and' >
                          <condition attribute='xyz' operator='eq' value='{xyz}' />
                        </filter>
                    </entity>
                </fetch>
            </fetchXML>
            <cascadingentities>
                <cascadingentity name='xyz'>
                    <fetchXML>
                        <fetch>
                            <entity name='xyz' >
                                <attribute name='xyz' />
                                <filter type='and' >
                                  <condition attribute='xyz' operator='eq' value='{xyz}' />
                                </filter>
                            </entity>
                        </fetch>
                    </fetchXML>
                    <cascadingentities>
                        <cascadingentity name='xyz'>
                            <fetchXML>
                                <fetch>
                                    <entity name='xyz' >
                                        <attribute name='xyz' />
                                        <filter type='and' >
                                          <condition attribute='xyz' operator='eq' value='{xyz}' />
                                        </filter>
                                    </entity>
                                </fetch>
                            </fetchXML>                         
                        </cascadingentity>
                    </cascadingentities>
                </cascadingentity>                                              
            </cascadingentities>
        </cascadingentity>
        <cascadingentity name='xyz'>
            <fetchXML>
                <fetch>
                    <entity name='xyz' >
                        <attribute name='xyz' />
                        <filter type='and' >
                          <condition attribute='xyz' operator='eq' value='{xyz}' />
                        </filter>
                    </entity>
                	</fetch>
            	</fetchXML>                         
        	</cascadingentity>
    	</cascadingentities>
    </rootentity>";
