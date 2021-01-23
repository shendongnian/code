    public class SpecialCharacter
    {
	    [XmlElement(ElementName = "special")]
        public String Base64
	    {
		    get
    		{
    			return Convert.ToBase64String(System.Text.Encoding.UTF32.GetBytes(special));
    		}
	    	set
    		{
    			if (value == null)
    			{
    				special = null;
    				return;
    			}
    			special = System.Text.Encoding.UTF32.GetString(Convert.FromBase64String(value));
	    	}
    	}
	
        [XmlIgnore]
        public String special = Char.ConvertFromUtf32(0x05).ToString();
    }
