    public class responseElementList
    {
    	[XmlAttribute("name")]
    	public String name { get; set; }
    
    	[XmlElement("valueList")]
    	public ValueModel valueList { get; set; }
    
    	[XmlElement("value")]
    	public List<ValueModel> value { get; set; }
    }
    
    public class ValueModel
    {
    	[XmlAttribute("name")]
    	public String name { get; set; }
    
    	[XmlText]
    	public String Value { get; set; }
    }
    
    public static T DeSerialize<T>(string xml)
    {
    	T result = default(T);
    	using (TextReader reader = new StringReader(xml))
    	{
    		var ser = new XmlSerializer(typeof(T));
    		result = (T)ser.Deserialize(reader);
    	}
    	return result;
    }
    
    void Main()
    {
    	var a = @"<responseElementList name='something'>
    <valueList name='NAT_TEXT'>XXX</valueList>
    <value name='XXX_MAIN'>NONE</value>
    <value name='XXX_SEC'>NONE</value>
    <value name='XXX_XXX'>NO</value>
    <value name='XXX'>YES</value>
    <value name='XXX_NET'>NO</value>
    </responseElementList>";
    	
    	var obj = DataHelper.DeSerialize<responseElementList>(a);
    	obj.Dump();
    }
