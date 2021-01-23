    public class Test
    {
        public string value = "Value";
        
        public Test child;
        public Test(Test childObject)
        {
            this.child = childObject;
        }
    }
