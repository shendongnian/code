    public class ClassA
    {
        public ClassA()
        {
            // Create Always complex type instances
            B = new ClassB();
            C = new ClassC();
        }
        [Key]
        public int id { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public ClassB B { get; set; } // virtual is not required by EF because this property won't be lazy loaded
        public ClassC C { get; set; }
        [ComplexType]
        public class ClassB
        {
            public int? b { get; set; }
        }
        [ComplexType]
        public class ClassC
        {
            public int? c { get; set; }
        }
    }
