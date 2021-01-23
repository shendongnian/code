    public sealed class BoolHolder
    {
        private BoolHolder() { }
        private static BoolHolder instance = null;        
        public static BoolHolder Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BoolHolder();
                }
                return instance;
            }
        }
        private bool _boolInQuestion;
        public bool BoolInQuestion
        {
            get { return _boolInQuestion; }
            set
            {
                _boolInQuestion = value;
                //call method to do something
            }
        }
    }
