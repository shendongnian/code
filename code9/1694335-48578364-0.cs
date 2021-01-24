    public class BaseClass
    {
       public virtual bool IsGood {get;}
    }
    public class DerivedClassA : BaseClass
    {
       public override bool IsGood {get { return CanTalk; }}
       public bool CanTalk {get; set;}
    }
    public class DerivedClassB : BaseClass
    {
       public override bool IsGood {get { return CanGrowl; }}
       public bool CanGrowl {get; set;}
    }
