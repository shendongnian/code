    public class TestClass
    {
    
        private int _first { get; set; }
    
        private int _second { get; set; }
    
        private int _third { get; set; }
    
        public TestClass(int first, int second, int third)
        {
            _first = first;
            _second = second;
            _third = third;
        }
    
        // Implementation for tuple deconstruct
        public void Deconstruct(out int first, out int second)
        {
            first = _first;
            second = _second;
        }
           
    }
   
