    public class BaseClass
    {
      private BaseClass _Parent;
      public virtual decimal Result
      {
         get
         {
          if (Parent == null)
            throw new NotImplementedException("Result property not valid");
          return Parent.Result;
        }
        set
        {
          throw new NotSupportedException("Result property cannot be set here");
        }
      }
    }
    public class DerivedClass : BaseClass
    {
      private decimal _Result;
      public override decimal Result
      {
        get { return _Result; }
        set { _Result = value;  }
      }
    }
