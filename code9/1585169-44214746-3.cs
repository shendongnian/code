    public inteface I1
    {
        void A();
    }
    public inteface I2
    {
        void B();
    }
    public partial class Partial : I1
    {
        public void A() { }
    }
    public partial class Partial : I2
    {
        public void B() { } 
    }
