    using System.Xml.Linq;
    ...
    var str = "Your XML";
    
    XDocument doc = XDocument.Parse(str);
    var element = doc.Root.Element("NodeToCheck");
    
    if ((element == null)) {
    	Console.WriteLine("Checkpoint passed");
    } else {
    	Console.WriteLine(element.Value);
    	Console.WriteLine("Checkpoint Failed");
    }
