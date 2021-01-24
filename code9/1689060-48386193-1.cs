    public partial class ClassOne
    {
        private int iD;
        public int ID
        {
            get { return iD; }
            set
            {
                iD = value;
            }
        }
    
        public void MyMethod()
        {
            ID = 22;
        }
    
        public static ClassOne createWithIdFact()
        {
          var returnValue = new ClassOne();
          returnValue.MyMethod();
          return returnValue;
        }
    }
