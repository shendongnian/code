    using StackExchange.Redis;
    
    // Will put this in contructor or config
    ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost");
    IDatabase db = redis.GetDatabase();
    
    // XML 
    XmlDocument re= new XmlDocument();
    re.Load(url);
    m_schema = (XmlSchemaSet)util.LoadSchema(urlSchema);
    msg = re.OuterXml;
    
    // Set value in cache with key
    db.StringSet("ID", value /*, TimeSpan for expiry*/); // Replace ID with the duplicate entry
    
    // Next time you want to process data... get the value / data 
    string value = db.StringGet("ID"); // Replace ID with the duplicate entry
    
    // check if exists in cache or is equal to the 'ID' then ignore otherwise process.
    if (value == "" || value  != "SomeIDToCheckAgainst")
    {
    	
    	//Process Info
    	string sqlInsert =" Into Sport( Id_Event , Teams , eventTime ) values('12','xxxx','xxxx') ";
    
    }
