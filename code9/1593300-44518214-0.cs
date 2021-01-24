    public abstract class AbstractClass
    {
        public abstract void method1();
        public void method2() {
            ...
            method1();
            ...
        }
    }
    public class ConcreteClass extends AbstractClass
    {
        public void method1() {
            ...
        }
    }
