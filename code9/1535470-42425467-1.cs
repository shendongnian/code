        SomeClass objectValue = MyConfig.Read<SomeClass>("someObjectProperty");
        public class SomeClass
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public SomeClass2 SomeChildeObject { get; set; }
        }
        public class SomeClass2
        {
            public int ChildObjectId { get; set; }
            public string ChildObjectName { get; set; }
        }
