      private const int MAXIMUM_AGE = 65;
      private int _age = MAXIMUM_AGE;
      [DefaultValue(MAXIMUM_AGE)]
      public int Age 
      {
        get { return _age; }
        set { _age = value; }
      }
