    Class A
    {
        private int someNumber;
        internal virtual int SomeNumber
        {
            get { return someNumber; }
            set { someNumber = value; }
        }
    }
    Class B : A
    {
        internal override int SomeNumber
        {
            get { return base.SomeNumber; }
            set
            {
                base.someNumber = value;
                SomethingINeedToRunWhenSettingSomeNumber();
            }
        }
    
        private void SomethingINeedToRunWhenSettingSomeNumber()
        {
            ...
        }
    }
