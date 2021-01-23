    //something like this
    class Group
    {
    public string Id{ get; set; }
    public string Field1{ get; set; }
    public string FieldN { get; set; }
    }
    var groups = from xe in xdoc.Element("ribbon").Element("tabs").Elements("tab").Elements("group")
            select new Group
            { 
                Id= xe.Attribute("id").Value, 
                Field1= xe.Element("Field1").Value, 
                FieldN  = xe.Element("FieldN ").Value 
            };
