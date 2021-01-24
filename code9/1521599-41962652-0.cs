    public class TestModel
    {
        public int a { get; set; }
        public int b { get; private set; }
    
        public int bSet 
        {
            set { b = value; }
        }
    }
