    enum PrimaryColor
    {
    	Red,
    	Blue,
    	Green
    }
    
    enum AttributedPrimaryColor
    {
    	[MyAttribute]
    	Red = PrimaryColor.Red,
    	[MyAttribute]
    	Blue = PrimaryColor.Blue,
    	[MyAttribute]
    	Green = PrimaryColor.Green
    }
    
    static void PrintColor(PrimaryColor color)
    {
    	Console.WriteLine(color);
    }
    void Main()
    {
        // We have to perform a cast to PrimaryColor here.
        // As they both have the same base type (int in this case)
        // this cast will be fine.
    	PrintColor((PrimaryColor)AttributedPrimaryColor.Red);	
    }
