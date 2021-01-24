        public class ParentClass
        {
             public ChildClass A { get; set; }
             public ChildClass2 B { get; set; }
        }
     
        public class ChildClass
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    
        public class ChildClass2
        {
            public string Color { get; set; }
            public string Nick { get; set; }
        }
    
        public class DTOClass
        {
            public int AId { get; set; }
            public string AName { get; set; }
            public string BColor { get; set; }
            public string BNick { get; set; }
        }
