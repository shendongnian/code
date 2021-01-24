    [Flags]
    public enum EyeColors
    {
        None = 0,
        Blue = 1 << 0,
        Cyan = 1 << 1,
        Brown = 1 << 2,
        Black = 1 << 3,
        Green = 1 << 4,
        Browngreen = Brown | Green,
        All = Blue | Green | Brown | Black | Cyan
    }
    
    void Main()
    {
    	EyeColors eyeColors = EyeColors.Brown;
    	Console.WriteLine(eyeColors);
    	
    	eyeColors = EyeColors.Brown & EyeColors.Green;
    	Console.WriteLine(eyeColors); // None
    	
    	eyeColors = EyeColors.Brown | EyeColors.Green;	
    	Console.WriteLine(eyeColors); // Brown green
	    eyeColors = (EyeColors)20;
     	Console.WriteLine(eyeColors);    	
    	eyeColors = EyeColors.All;
    	Console.WriteLine(eyeColors);
    }
