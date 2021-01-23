    public class A
    {
        public virtual void GetName()
        {
            Console.Write(Name);
        }
    }
    public class B : A
    {
        public override void GetName()
        {
            base.GetName();
            Console.Write(new string(Name.Reverse().ToArray()));
        }
    }
