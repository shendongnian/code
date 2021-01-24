    public inteface I1
    {
        void A();
    }
    public inteface I2
    {
        void A();
    }
    public partial class Partial : I1
    {
        public override A() { }
    }
    public partial class Partial : I2
    {
        public override B() { } 
    }
