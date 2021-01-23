    public class MySubClass : SecondBase
    {
        public FirstBase firstBase;
        public SecondBase secondBase;
    
        public MySubClass()
        {
            firstBase = this;
            secondBase = this;
        }
    }
