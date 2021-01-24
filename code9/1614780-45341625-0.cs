    [Flags]
    public enum EFlagsBmp 
    {
        ...
    }
    public static class EFlagsBmpHelper
    {
    	public static bool TR1(this EFlagsBmp flags)
    	{
    		return !flags.HasFlag(EFlagsBmp.SB1) && !flags.HasFlag(EFlagsBmp.SB2);
    	}
    	public static bool TR2(this EFlagsBmp flags)
    	{
    		return flags.HasFlag(EFlagsBmp.SB1) && !flags.HasFlag(EFlagsBmp.SB2);
    	}
    	public static bool TR3(this EFlagsBmp flags)
    	{
    		return !flags.HasFlag(EFlagsBmp.SB1) && flags.HasFlag(EFlagsBmp.SB2);
    	}
    	public static bool TR4(this EFlagsBmp flags)
    	{
    		return flags.HasFlag(EFlagsBmp.SB1) && flags.HasFlag(EFlagsBmp.SB2);
    	}
    }
