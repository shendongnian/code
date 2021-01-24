    public interface IA
    {
        string Value { get; set; }
    }
    public class A : IA
    {
        public String Value { get; set; }
    }
    public class B
    {
        public virtual IA Prop { get; set; }
    }
    public class C : B
    {
        public override IA Prop { get; set; }
        public C()
        {
            Prop = new A();
            Prop.Value = "test C";
        }
    }
