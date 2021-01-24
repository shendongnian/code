    public class A
    {
        public B B { get; set; }
    }
    public class B
    {
        public virtual ICollection<A> A { get; set; }
    }
