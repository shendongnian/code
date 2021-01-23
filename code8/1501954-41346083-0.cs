    class Object
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Language { get; set; }
    
        List<Object> Objects { get; set; }
    }
   
    class ObjectFinder
    {
        private XElement xmlContent;
        public ObjectFinder(string filePath)
        {
            xmlContent = XElement.Load(filePath);
        }
        public List<Object> Objects()
        {
            List<Object> list = new List<Object>();
            return xmlContent.Elements().Select(obj =>
            {
                return new Object
                {
                    Description = obj.Attribute("Description").Value,
                    Language = obj.Attribute("Language").Value,
                    Name = obj.Value,
                    Type = obj.Attribute("Type").Value
                };
            }).ToList();
        }
    }
