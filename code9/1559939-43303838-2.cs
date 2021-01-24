    class Customer
    {
        public virtual string Cname
        {
            get { return _cnmae; }
            set
            {
                if (_status != 0 & _bal >= 500)
                {
                    SetCnameUnconditionally(value);
                }
            }
        }
        // This method allows subclasses to bypass the conditions
        // in the normal setter
        protected void SetCnameUnconditionally(string value)
        {
            _cnmae = value;
        }
    }
    class SpecialClass
    {
        public override string Cname
        {
            get { return base.Cname; }
            set
            {
                if (value == "SPECIAL")
                {
                    SetCnameUnconditionally(value);
                }
            }
        }
    }
