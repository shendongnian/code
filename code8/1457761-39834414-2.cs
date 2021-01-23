    void Main()
    {
    	Test(EnumA.First);
    	Console.WriteLine("-----");
    	Test(EnumB.B);
    }
    
    void Test(Enum theEnum)
    {
    	foreach (string element in Enum.GetNames(theEnum.GetType()))
    	{
    		Debug.WriteLine(element + " = " + (int) Enum.Parse(theEnum.GetType(), element));
    	}
    }
    
    enum EnumA
    {
    	First = 1,
    	Second = 2
    }
    
    enum EnumB
    {
    	A = 1,
    	B = 2,
    	C = 3
    }
