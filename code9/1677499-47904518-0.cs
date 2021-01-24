    static void Main(string[] args)
    {
    	var xmlstr = 
    		@"<example>
    			<ReferenceNumber xmlns='http://www.example.com/schemas/core/movement'>
    			<Mnemonic>LHH1</Mnemonic>
    			<MovementProjectNumber>4743</MovementProjectNumber>
    			<MovementVersion>5</MovementVersion>
    			</ReferenceNumber>
    		 </example>";
    	XNamespace ns = "http://www.example.com/schemas/core/movement";
    	var xml = XDocument.Parse(xmlstr);    
    
    	var MovementVersionNew = (from MovVer in xml.Root.Element(ns + "ReferenceNumber").Elements(ns + "MovementVersion")
    								select MovVer.Value.ToList().FirstOrDefault().ToString()).ToList();
    
    	var MovementVersionRef = (from MovVer in xml.Root.Elements(ns + "ReferenceNumber")
    								select MovVer).ToList();
    
    	foreach (XElement element in MovementVersionRef.Descendants())
    	{
    		if (!element.HasElements)
    		{
    			if (element.Name.ToString().Contains("MovementVersion"))
    			{
    				element.Value = String.Empty;
    			}
    		}
    	}
    	MovementVersionNew.ForEach(Console.WriteLine); //Prints "5"
    	MovementVersionRef.ForEach(Console.WriteLine);
    }
