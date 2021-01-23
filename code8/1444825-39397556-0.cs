    public UsefulObject : NotUsefulObject 
    {
        public int MyProperty 
        {
           get
           {
              return base.MyProperty; // this is arbitrary you can do it however you want.
           }
           set
           {
              MyProperty = value;
           }
        }
    }
