    public void CleanXML(string daysText)
    {
       int days = Int32.Parse(daysText);
       DateTime minDate = DateTime.Now.AddDays(-days);
       var root = XElement.Load(pathToXml);
       // keep list of items to be removed
       var remove = new List<XElement>();
       foreach (XElement el in root.Elements("OFBM"))
       {
           foreach (XAttribute el2 in el.Attributes("date"))
           {
               string rawDate = el2.Value;
               DateTime xmlDate = Convert.ToDateTime(rawDate);
    
               if (xmlDate < minDate)
               {
                   Console.WriteLine(xmlDate + " lower than " + minDate + " Retention: " + days);
    			   // keep a reference to this element
                   remove.Add(el);
               }
           } 
        }
    	// remove individual elements
    	foreach(var element in remove)
    	{
    	  element.Remove();
    	}
        root.Save(pathToXml);
    }
