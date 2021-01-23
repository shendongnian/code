    public abstract class A 
    {
        public string varA = "Default";
        public B InstanceOfB { get; set; }
    }
    public abstract class B 
    {
        public abstract void SomethingCool(int[] val);
    }
    public class C : A
    {
        public override void SomethingCool(int[] val)
        { 
            //do something cool 
        }
    }
