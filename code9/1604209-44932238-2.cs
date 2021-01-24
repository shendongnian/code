    using System;
    using System.ComponentModel;
    using System.Reflection;
    					
    public static class Program
    {
    	public const string String1 = "First String";
    	public const string String2 = "Second String";
    	public enum RestrictedStrings
    	{
    		[Description("First String")]
    		String1,
    		[Description("Second String")]
    		String2
    	}
    	
    	public static string GetDescription(Enum en)
            {
                Type type = en.GetType();
    
                MemberInfo[] memInfo = type.GetMember(en.ToString());
    
                if (memInfo != null && memInfo.Length > 0)
                {
                    object[] attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
    
                    if (attrs != null && attrs.Length > 0)
                    {
                        return ((DescriptionAttribute)attrs[0]).Description;
                    }
                }
    
                return en.ToString();
            }
    	
    	
    	public static void Main()
    	{
    		string description = Program.GetDescription(Program.RestrictedStrings.String1);
    		Console.WriteLine(description);
    	}
    }
    // Output: First String
