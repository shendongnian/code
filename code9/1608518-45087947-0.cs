    class A 
    {
    
      public virtual bool Before() { return false; }
      
      public void BaseMethod () 
      {      	
    	  if(Before())
    		 Console.WriteLine("Called method AMethod");
      }
    }
    
    class B : A 
    {    
    	public override bool Before() {return true; }
    }
    
    class C : A 
    {    
    }
    
    void Main()
    {
    	var c = new C(); 
    	var b = new B(); 
    	
    	c.BaseMethod(); 
    	b.BaseMethod();
    }
