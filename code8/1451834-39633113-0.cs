    using System;
    using System.Xml;
    using System.Xml.Linq;
    					
    public class Program
    {
    	public enum testTypes { test1, test2, test3};
    	
    								
    	private static testTypes GetEnumValue(XElement x, string tag)
        {
    		if (x.Element(tag)!=null) {
    			var v = x.Element(tag).Value.ToString();
    			var testEnums = Enum.GetValues(typeof(testTypes));
    			foreach (testTypes enumType in testEnums) {
    				if (v.Equals((testTypes) enumType))	return enumType;
    			}
    		}
            return (testTypes) 0;
        }
    
    	public static void Main()
    	{
    	    
    		XElement x = new XElement("MyType","Test1");
    		var EnumVal = GetEnumValue(x, "MyType");    
    		Console.WriteLine("Type is {0}",(testTypes) EnumVal);
    	
    	}
    }
