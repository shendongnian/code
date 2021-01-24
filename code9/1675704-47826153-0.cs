    class A
    {
      B b1;
      public A(B b){
        b1 = b;
      }
      double Apple { get; set; }    
      public void PrintAfromB() {
        Console.WriteLine("Calling method from B where input involved: "+ b1.CallB());
      }
  
      public void PrintAfromBB() {
        Console.WriteLine("Calling method from B where input not involved: " + b1.CallBB());
      }
    }
