    public class MainType
    {
    	public static MainType One { get; } = new MainType();
    	public static MainType Two => SubType.Two;
    }
    
    public sealed class SubType : MainType
    {
    	public new static SubType Two { get; } = new SubType();
    }
