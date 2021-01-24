    public static class Constants
    {
        public static Dictionary<string, MyObject> myDictionary
        {
            get
            {
                return new Dictionary<string, MyObject>()
                {
                    { "first",  new MyObject()},
                    { "second", new MyObject()},
                };
            }
        }
        static Dictionary<string, MyObject> _myOtherDictionary;
        public static Dictionary<string, MyObject> myOtherDictionary
        {
            get
            {
                _myOtherDictionary = myDictionary;
                _myOtherDictionary.Remove("first");
                _myOtherDictionary.Add("third", new MyObject());
                return _myOtherDictionary;
            }
        }
    }
