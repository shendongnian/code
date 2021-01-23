   	public static void Source(String source) /// Constructor
    {
        try
        {
            var request = WebRequest.Create(source);
            var stream = request.GetResponse().GetResponseStream();			
            XmlDocument doc = new XmlDocument();
            doc.Load(stream);
        }
		catch(XmlException e) 
		{
		   Console.WriteLine("XmlException Caught");
		   Console.WriteLine(e.Message);
		   Console.WriteLine("Exception object Line, pos: (" + e.LineNumber + "," + e.LinePosition  + ")");
		}		
        catch (Exception ex)
        {
			Console.WriteLine("Exception Caught");
			Console.WriteLine(ex.Message);
        }
    }
