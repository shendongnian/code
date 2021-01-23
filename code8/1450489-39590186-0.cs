    string xmlInput =  @"
    <root>
    <element>
    <timestamp time='2016-09-15T13:45:30'>
    </timestamp>
    </element>
    <element>
    <timestamp time='2016-10-16T13:45:30'>
    </timestamp>
    </element>
    </root>";
    	
    XDocument  xdoc = XDocument.Parse(xmlInput);
    var listOfDates = xdoc.Descendants("root").Elements("element").Select(x => DateTime.Parse(x.Element("timestamp").Attribute("time").Value,CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind)).ToList<DateTime>();
    Console.WriteLine(listOfDates[0]);
