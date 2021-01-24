    XElement  root = XElement.Load("Some file");
    List<string> urls;
    
    //Query Syntax
    urls = (from e in root.Elements(d + "element")
            where e.Element(d + "Key").Value == "Path"
            select e.Element(d + "Value").Value);
    //Or
    //Method Syntax
    urls = (from e in root.Elements(d + "element")
            where e.Element(d + "Key").Value == "Path"
            select e.Element(d + "Value").Value).ToList();
    
    Console.WriteLine(string.Join(",", urls));
