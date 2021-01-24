    public class A
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
        protected virtual void SomethingINeedToRunWhenSettingSomeNumber()
        {
            // Do something generic to A.
        }
    }
    public class B : A
    {
        protected override void SomethingINeedToRunWhenSettingSomeNumber()
        {
            // Do something specific to B.
        }
    }
