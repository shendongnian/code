    public class MyClass
    {
        private readonly IMyClassLookup _myClassLookup;
    
        public MyClass(IMyClassLookup myClassLookup)
        {
            _myClassLookup = myClassLookup;
        }
    
        public Method()
        {
            Table001 table001 = _myClassLookup.GetTable001(/* fields */);
            Table002 table002 = _myClassLookup.GetTable002(/* fields */);
            Table003 table003 = _myClassLookup.GetTable003(/* fields */);
            ...
        }
    }
