    public class Module
    {
        public string Name { get; set; }
    
        public List<Field> Fields { get; set; }
    }
    
    public class Field
    {
        public string AttributeName { get; set; }
        public string AttributeType { get; set; }
    }
    XDocument loXDocument = XDocument.Parse(lsXmlString);
    var loList = (from module in loXDocument.Descendants("Module")
                    let fields = module.Descendants("Field").Select(item => new Field
                    {
                        AttributeName = item.Element("AttributeName").Value,
                        AttributeType = item.Element("AttributeType").Value,
                    })
                    select new Module
                    {
                        Name = module.Attribute("Name").Value,
                        Fields = fields.ToList()
                    }).ToList();
    
    foreach (var loModule in loList)
    {
        Console.WriteLine($"Module: {loModule.Name}");
        foreach (var loField in loModule.Fields)
            Console.WriteLine($"AttributeName: {loField.AttributeName}, AttributeType{loField.AttributeType}");
    }
