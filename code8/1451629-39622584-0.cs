    public abstract class Base
    {
        public void TemplateMethod()
        {
            AbstractMethod1();
            AbstractMethod2();
        }
        public abstract void AbstractMethod1();
        public abstract void AbstractMethod2();
    }
    public class Concrete : Base
    {
        public override void AbstractMethod1()
        {
            Console.Write("Override Abstract Method 1");
        }
        public override void AbstractMethod2()
        {
            Console.Write("Override Abstract Method 2");
        }
    }
    public class Main
    {
        public Main()
        {
            var concrete = new Concrete();
            concrete.TemplateMethod();
        }
    }
