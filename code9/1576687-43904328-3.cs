    public class BaseClass
    {
        public virtual bool? BaseBoolNullable { get; set; }
        public virtual int BaseInt { get; set; }
    }
    
    public class DerivedClass : BaseClass
    {
    	public override bool BaseBoolNullable { get; set; }
    	public override int? BaseInt { get; set; }
    }
