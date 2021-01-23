    <configuration>
      <system.web>         
         <sessionState timeout="60"></sessionState>
      </system.web>
    </configuration>
    XmlDocument xmlDoc
    {
        get { return (XmlDocument) Session["xmlDocKey_3069"]; }
        set { Session["xmlDocKey_3069"] = value; }
    }
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (xmlDoc == null)
        {
            var xml = File.ReadAllText(Server.MapPath(@"request.xml"));
            xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xml);
        }
    
        doStuff();
    }
