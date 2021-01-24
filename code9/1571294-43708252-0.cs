    interface IGate
    {
      bool Value { get; }
    }
    
    class And : IGate
    {
      public IGate X { get; private set; }
    
      public IGate Y { get; private set; }
    
      public bool Value
      {
        get
        {
          return X.Value && Y.Value;
        }
      }
    
      public And(IGate x, IGate y)
      {
        X = x;
        Y = y;
      }
    
    }
    
    class Input : IGate
    {
      public bool Value { get; set; }
    
      public Input(bool value)
      {
        Value = value;
      }
    
    }
