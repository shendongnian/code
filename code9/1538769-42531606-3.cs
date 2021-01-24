    public void Test()
    { 
    
    	//create data and write it to xml
    	CreateData();
    	//load data from xml
    	Data data = LoadData();
    	//iterate thru collection if needed
    	foreach (Page page in data.Pages)
    	{
    		System.Diagnostics.Debug.WriteLine(string.Format("page number {0}, value: {1}" + (data.Pages.IndexOf(page) + 1), page.Value));
    	}
    	//access second page (by index... index 1 is page 2)
    	var specificPage = data.Pages[1];
    	//add additional page and sort it by value
    	data.Pages.Add(new Page() { Value = 15 });
    	data.Pages.OrderBy(x => x.Value);
    	//write again if needed
    	WriteToXml(data);
    
    }
    
    private void CreateData()
    {
    	Data data = new Data();
    	data.Pages = new List<Page>();             
    	data.Pages.Add(new Page() { Value = 10 });
    	data.Pages.Add(new Page() { Value = 20 });
    	data.Pages.Add(new Page() { Value = 30 });
    
    	WriteToXml(data);
    	
    }
    
    private void WriteToXml(Data data)
    {
    	XmlSerializer xSer = new XmlSerializer(typeof(Data));
    	using (TextWriter writer = new StreamWriter(@"c:\temp\pages.xml"))
    	{
    		XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
    		ns.Add("", "");
    		xSer.Serialize(writer, data, ns);
    	}
    }
    
    private Data LoadData()
    {
    	XmlSerializer xSer = new XmlSerializer(typeof(Data));
    	using (TextReader reader = new StreamReader(@"c:\temp\pages.xml"))
    	{
    		return xSer.Deserialize(reader) as Data;
    	}
    }
