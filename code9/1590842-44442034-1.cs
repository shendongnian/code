    using System;
    using System.Linq;
    using System.Xml.Linq;
    namespace ParseXml {
    class Program {
        static void Main(string[] args) {
            var xml = @"
    <root>
	<SectionItem>
		 <Cell columnid='1' InSeconds='1496761802'>06/06/2017  03:10:02 PM</Cell>
		 <Cell columnid='2'> Error</Cell>
		 <Cell columnid='3'> abc</Cell>
		 <Cell columnid='4'>  None</Cell>
		 <Cell columnid='5'>  1 </Cell>
		 <Cell columnid='6'> N/A</Cell>
		 <Cell columnid='7'> efg</Cell>
	 </SectionItem>
	 <SectionItem>
		 <Cell columnid='1' InSeconds='1496743990'>06/06/2017  10:13:10 AM</Cell>
		 <Cell columnid='2'> Error</Cell>3
		 <Cell columnid='3'> o</Cell>
		 <Cell columnid='4'> None</Cell>
		 <Cell columnid='5'> 1 </Cell>
		 <Cell columnid='6'>  N/A </Cell>
		 <Cell columnid='7'> ice age</Cell>
	 </SectionItem>
	 <SectionItem>
		 <Cell columnid='1' InSeconds='1496227357'>31/05/2017  10:42:37 AM</Cell>
		 <Cell columnid='2'> Error</Cell>
		 <Cell columnid='3'>  Microsoft-Windows-CAPI2</Cell>
		 <Cell columnid='4'>  N/A</Cell>
		 <Cell columnid='5'> 513</Cell>
		 <Cell columnid='6'> N/A</Cell>
		 <Cell columnid='7'>Access is denied.. </Cell>
	 </SectionItem>
	 <SectionItem>
		 <Cell columnid='1' InSeconds='1495568786'>23/05/2017  07:46:26 PM</Cell>
		 <Cell columnid='2'> Error</Cell>
		 <Cell columnid='3'> Microsoft-Windows-Immersive-Shell</Cell>
		 <Cell columnid='4'>  N/A</Cell>
		 <Cell columnid='5'>2484</Cell>
		 <Cell columnid='6'>SR</Cell>
		 <Cell columnid='7'>hello</Cell>
	 </SectionItem>
	 <SectionItem>
		 <Cell columnid='1' InSeconds='1495568789'>23/05/2017  07:46:29 PM</Cell>
		 <Cell columnid='2'>Error</Cell>
		 <Cell columnid='3'> Application Hang </Cell>
		 <Cell columnid='4'> N/A</Cell>
		 <Cell columnid='5'>1002</Cell>
		 <Cell columnid='6'> N/A</Cell>
		 <Cell columnid='7'> here is a error</Cell>
	 </SectionItem>
	 <SectionItem>
		 <Cell columnid='1' InSeconds='1495568740'>23/05/2017  07:45:40 PM</Cell>
		 <Cell columnid='2'> Error</Cell>
		 <Cell columnid='3'> Application Error</Cell>
		 <Cell columnid='4'> Application Crashing Events</Cell>
		 <Cell columnid='5'>1000</Cell>
		 <Cell columnid='6'> N/A</Cell>
		 <Cell columnid='7'> error number 3</Cell>
	 </SectionItem>
    </root>";
        var sortCol = "3";
        var xdoc = XDocument.Parse(xml);
        var cells = xdoc.Element("root")
                        .Elements("SectionItem")
                        .Elements("Cell")
                        .Where(x => x.Attribute("columnid").Value == sortCol)
                        .OrderBy(x => ParseCol(sortCol, x));
        var newDoc = new XDocument();
        var root = new XElement("root");
        newDoc.Add(root);
        foreach (var c in cells) {
            root.Add(c.Parent);
            }
        Console.WriteLine(newDoc.ToString(SaveOptions.None));
        }
        static object ParseCol(string col, XElement x) {
            switch (col) {
            case "1":
                return long.Parse(x.Attribute("InSeconds").Value);
            case "2":
            case "3":
            case "4":
                return x.Value.Trim();
            case "5":
                return long.Parse(x.Value);
            case "6":
            case "7":
                return x.Value.Trim();
            default:
                throw new ArgumentException("Bad column id string");
            }
        }
    }
