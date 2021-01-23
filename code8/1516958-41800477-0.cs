    public abstract class A
    {
        public int Sum { set; get; }
        public virtual void add(int a, int b)
        {
            Sum = a + b;
        }
    }
    class B : A
    {
        public override void add(int a, int b)
        {
            //do your sufff
            //call base method of class A
            base.add(a, b);
        }
    }
