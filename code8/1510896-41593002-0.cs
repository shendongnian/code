    abstract class A
    {
        protected abstract void SomeMethod();
    }
    abstract class B { }
    class AA : A
    {
        public class BB : B
        {
            public void Test(AA a) => a.SomeMethod(); // no problem to access it here
        }
        protected override void SomeMethod() { } // is not public
    }
