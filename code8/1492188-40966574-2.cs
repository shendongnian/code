    class Baseclass
    {
    	public virtual void fun()
        //     ^^^^^^^
    	{
    		Console.Write("Base class" + " ");
    	}
    }
    class Derived1 : Baseclass
    {
    	public override void fun()
    //  ^^^^^^ ^^^^^^^^
    	{
    		Console.Write("Derived1 class" + " ");
    	}
    }
    class Derived2 : Derived1
    {
    	public override void fun()
    //  ^^^^^^ ^^^^^^^^
    	{
    		Console.Write("Derived2 class" + " ");
    	}
    }
