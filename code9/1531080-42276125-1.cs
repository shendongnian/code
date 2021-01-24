    interface IBase {void Method();}
    class Derived1: IBase { void Method(); }
    class Derived2: IBase { void Method(); }
    static void Main(string[] args) {   
      IBase instance; 
      if (some condition is true)
        instance = new Derived1();
      else
        instance = new Derived2();
      instance.Method();
    }
