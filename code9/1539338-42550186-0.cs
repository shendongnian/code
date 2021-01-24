    void Main()
    {
    	string soapMessage = "<Name>{{Name}}</Name>";
    	soapMessage = ReplaceToken(soapMessage, "Name", "NameValue");
    }
    
    public string ReplaceToken(string soapMessage, string tokenName, string value)
    {
    	return soapMessage.Replace("{{" + tokenName + "}}", value);
    }
