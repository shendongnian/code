    Class A
    {
        private int someNumber;
        internal virtual int SomeNumber
        {
            get { return someNumber; }
        }
    }
    Class B : A
    {
        internal override int SomeNumber
        {
            get { return base.SomeNumber; }
            set
            {
                base.SomeNumber = value;
                SomethingINeedToRunWhenSettingSomeNumber();
            }
        }
    
        private void SomethingINeedToRunWhenSettingSomeNumber()
        {
            ...
        }
    }
