    [Flags]
    public enum EyeColors
    {
        None = 0,
        Blue = 1 << 0, // 1
        Cyan = 1 << 1, // 2
        Brown = 1 << 2, // 4
        Black = 1 << 3, // 8
        Green = 1 << 4, // 16
        Browngreen = Brown | Green,
        All = Blue | Green | Brown | Black | Cyan
    }
    
    void Main()
    {
		EyeColors eyeColors = EyeColors.Brown;
		Console.WriteLine(eyeColors + " (" + (int)eyeColors + ")");
		
		eyeColors = EyeColors.Brown & EyeColors.Green;
		Console.WriteLine(eyeColors + " (" + (int)eyeColors + ")"); // None
			
		eyeColors = EyeColors.Brown | EyeColors.Green;	
		Console.WriteLine(eyeColors + " (" + (int)eyeColors + ")"); // Brown green
			
		eyeColors = (EyeColors)20;
		Console.WriteLine(eyeColors + " (" + (int)eyeColors + ")"); // Brown green also
			
		eyeColors = EyeColors.All;
		Console.WriteLine(eyeColors + " (" + (int)eyeColors + ")");
    }
