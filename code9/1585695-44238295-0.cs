    async Task<your_type> DeserialseXMLStringFromURL(string url)
    {
	    var xmlstring = await httpRequest(url);
	    XmlSerializer serializer = new XmlSerializer(typeof(List<your_type>));//initialises the serialiser
	    List<your_type> deserializedList;
	    deserializedList = (List<your_type>)serializer.Deserialize (xmlstring);
	    return deserializedList;
    }
    // Create a class for your type with properties.
    public class your_type
    {
	    [XmlElement("property_name_in_xml")]
	    public string Property_One{ get; set;}
	
	   ....
    }
