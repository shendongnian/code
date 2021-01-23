    //something like this
    class Group
    {
    public string Field1{ get; set; }
    public string FieldN { get; set; }
    }
    var groups = from xe in xdoc.Element("ribbon").Element("tabs").Elements("tab").Elements("group")
            select new Group
            { 
                Field1= xe.Attribute("Field1").Value, 
                FieldN  = xe.Element("FieldN ").Value 
            };
