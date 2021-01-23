    namespace myApplication.MyModel
    {
      public partial class myEntityName
      {
        public myEntityName(bool InitialiseOnConstruct) : this()
        {
          if (InitialiseOnConstruct) 
          {
            this.property1 = defaultValue1;
            this.property2 = defaultValue1;     
          }
        }
      }
    }
 
