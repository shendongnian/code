    public abstract class A<T>
    {
        public virtual void MyFunc() { ... }
    }
    public MyClass : A<string>
    {
        public override void MyFunc() { ... }
    }
