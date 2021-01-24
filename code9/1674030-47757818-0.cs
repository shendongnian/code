    abstract class Foo
    {
        public void Bar()
        {
            //  some code defined in the parent class
            BarCore(); // the customized part of it as defined in the child class
        }
        protected virtual void BarCore() { }
    }
