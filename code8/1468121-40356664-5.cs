    public class MainType
    {
    	public abstract class Fields
    	{
    		public static readonly MainType One = new MainType();
    		public static readonly MainType Two = SubType.Fields.Two;
    	}
    }
    
    public sealed class SubType : MainType
    {
    	public new abstract class Fields : MainType.Fields
    	{
    		public new static readonly SubType Two = new SubType();
    	}
    }
