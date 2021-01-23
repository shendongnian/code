    class AppStart
    {
        OneClass One;
        int _whatToCreate = 0;
        public int WhatToCreate
        {
            get { return _whatToCreate; }
            set { _whatToCreate = value; }
        }
        public void Start()
        {
            if (_whatToCreate > 0)
            {
                One = new OneClass(new OtherClass());
            }
            else
            {
                One = new OneClass(new OtherClass2());
            }
            One.PerformSomething();
        }
    }
    class OneClass
    {
        IDoSomething _doSomething;
        public OneClass(IDoSomething doSomething)
        {
            _doSomething = doSomething;
        }
        public void PerformSomething()
        {
            _doSomething.DoSomething();
        }
    }
    
    class OtherClass : IDoSomething
    {
        public void DoSomething()
        {
            //throw new NotImplementedException();
        }
    }
    class OtherClass2 : IDoSomething
    {
        public void DoSomething()
        {
            //throw new NotImplementedException();
        }
    }
    interface IDoSomething
    {
        void DoSomething();
    }
