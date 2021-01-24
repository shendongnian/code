    namespace ConsoleApplication9
    {
        public class RelationshipAttribute : System.Attribute
        {
            public string Name { get; set; }
            public RelationshipAttribute(string name) { Name = name; }
        }
        [Relationship("RelationShipA")]
        public class Class1 { }
        [Relationship("RelationShipB")]
        public class Class2 { }
        [Relationship("RelationShipC")]
        public class Class3 { }
    }
