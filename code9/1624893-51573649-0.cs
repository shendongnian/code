    using System.Collections.Generic;
    					
    public static class ColorUtils
    {	
    	private static IReadOnlyDictionary<string, string> ColorMapping = new Dictionary<string, string>
    	{
    		["#F0F8FF"] = "AliceBlue",
    		["#FAEBD7"] = "AntiqueWhite",
    		//... the other 136 colors
    		["#FFFF00"] = "Yellow",
    		["#9ACD32"]	= "YellowGreen" 
    	};
    	
    	/// <summary>
    	/// Returns the color name or null if the name is not found.
    	/// </summary>
    	public static string ToColorName(string htmlColor)
    	{
    		ColorMapping.TryGetValue(htmlColor, out var name);
        	return name;
    	}
    	   
    }
