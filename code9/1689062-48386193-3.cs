    public partial class ClassOne
    {
        private static nexId = 0;
        private int iD;
        public int ID
        {
            get { return iD; }
            set
            {
                iD = value;
            }
        }
    
        public ClassOne()
        {
          this.iD = nextId++; // not thread safe
        }
    
        public static ClassOne createWithIdFact()
        {
          var returnValue = new ClassOne();
          return returnValue;
        }
    }
