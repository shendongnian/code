    private class MyClass
    {
        public MyClass(string field1, double field2, int field3)
        {
            this.Field1 = field1;
            this.Field2 = field2;
            this.Field3 = field3;
        }
        public string Field1 { get; set; }
        public double Field2 { get; set; }
        public int Field3 { get; set; }
    }
    var lists = new List<MyClass>{
        new MyClass( "zxc", 0.1, 3), 
        new MyClass( "dfg", 0.3, 7), 
        new MyClass( "abc", 0.8, 3), 
        new MyClass( "fhc", 1.7, 8), 
        new MyClass( "ghr", 5.5, 9)  
    };
    var result = lists.Where(mc => mc.Field2 > 1).ToList();
