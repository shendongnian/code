    public abstract class A
    {
        private int _someNumber;
        internal int SomeNumber
        {
            get { return _someNumber; }
            set
            {
                _someNumber = value;
                SomethingINeedToRunWhenSettingSomeNumber();
            }
        }
        protected abstract void SomethingINeedToRunWhenSettingSomeNumber();
    }
    public class B : A
    {
        protected override void SomethingINeedToRunWhenSettingSomeNumber()
        { }
    }
