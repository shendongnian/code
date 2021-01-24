    public class Test 
    {
        private string _x;
        private int xCounter = 0;
        public string X 
        {
            set
            {
               if(xCounter > 1) throw new Exception("DUPES");
                xCounter++;
               _x = value;
            }
            get
            {
               return _x;
            }
        }
    }
