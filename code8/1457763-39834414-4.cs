    void Main()
    {
    	Test(EnumA.First);
    	Console.WriteLine("-----");
    	Test(EnumB.B);
    }
    
    void Test(Enum theEnum)
    {
    	Type t = theEnum.GetType();
    	foreach (string element in Enum.GetNames(t))
    	{
    		Debug.WriteLine(element + " = " + (int) Enum.Parse(t, element));
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
