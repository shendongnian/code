    // this will be an instance in wsResponse
    class response
    {   public response() {
          data = Enumerable.Range(1,10).Select(id => new FoodCode(id)).ToArray();
       }
       public FoodCode[] data;
    }
    
    class FoodCode
    {
        public int ID;
        public string Item_Name;
        public string Code;
        public int ItemID;
        public int FoodCodeID;
        public string Brief_Descriptor;
        public string Full_Descriptor;
        public string Guidesheet;
        public string REG;
        public string Status;
        
        public FoodCode()
        {
            // populate all fields with random stuff
            foreach(FieldInfo fi in this.GetType().GetFields())
            {
                if (fi.FieldType == typeof(string)) {
                    fi.SetValue(this, GenString(fi.Name, ID));
                } else
                {
                    fi.SetValue(this, rnd.Next(1,255));
                }
            }
        }
        
        public FoodCode(int id):this()
        {
            ID = id;
        }
        
        static Random rnd = new Random();
        // generate a random string
        private string GenString(string name, int id)
        { 
        var result = new string[] { name, id.ToString(), new String(Enumerable.Range(0,5000).Select(_=> (char) rnd.Next(33,127)).ToArray())};
        return String.Join("-", result);
        }
    
    }
