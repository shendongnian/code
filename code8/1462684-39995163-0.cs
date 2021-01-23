    class A 
    {
       private string PropA; 
    }
    class B : A
    {
     public string PropB;
    }
    class C
    {
      var classB_instance = new B();     
    }
