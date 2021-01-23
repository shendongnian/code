    public static void Main()
    	{
    		var xDoc = XDocument.Parse(xmlString);
    		var xDoc1 =  XDocument.Parse(xmlString1);
    		Console.WriteLine(xDoc.ToString()==xDoc1.ToString());
    		xDoc.Elements().Elements("lastModifiedDateTime").Remove();
    		xDoc1.Elements().Elements("lastModifiedDateTime").Remove();
    		Console.WriteLine(xDoc.ToString()==xDoc1.ToString());
    	}
    	private static string xmlString = @"<action><actionSetID>2017_01_03_20_03_52_04_0001</actionSetID><lastModifiedDateTime dt=""dateTime"">2017-01-03T20:01</lastModifiedDateTime></action>";
    	private static string xmlString1 = @"<action><actionSetID>2017_01_03_20_03_52_04_0001</actionSetID><lastModifiedDateTime dt=""dateTime"">2017-01-03T20:03</lastModifiedDateTime></action>";
