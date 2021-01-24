    abstract class A
    {
        public abstract void DoSomething();
        protected abstract void DoSomethingAnotherName();
    }
    abstract class SuperA : A
    {
        private new void DoSomething()
        {
            ((A)this).DoSomething();
        }
    }
    sealed class FinalA : SuperA
    {
        public override void DoSomething() { }
        protected override void DoSomethingAnotherName() { }
    }
