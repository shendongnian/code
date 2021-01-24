    public enum MyEnum
    {
    	Nothing = 0,
    	One = 1,
    	Two = 2,
    	Four = 4,
    	Seven = 7
    }
    MyEnum seven = MyEnum.Seven;
    
    if( (seven & MyEnum.Four) == MyEnum.Four)
    {
    Console.WriteLine("Four");
    }
    
    
    if((seven & MyEnum.Two) == MyEnum.Two)
    {
    Console.WriteLine("Two");
    }
    
    if((seven & MyEnum.One) == MyEnum.One)
    {
    Console.WriteLine("One");
    }
