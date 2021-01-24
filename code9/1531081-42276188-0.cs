    interface Base{
    void Method();
    }
    
    class Derived1: Base { void Method(){} }
    class Derived2: Base { void Method(){}}
    
        static void Main(string[] args)
    {   
        Base obj; //it is just a declaring
    
        if (some condition is true)
            obj = new Derived1();
        else
            obj = new Derived2();
    
     //Call it directly
            obj.Method();    
    }
