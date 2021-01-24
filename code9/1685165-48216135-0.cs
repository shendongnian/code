    interface I1 { 
        int Foo();
    }
    
    interface I2 {
        string Foo();
    }
    
    class C : I1, I2 {
        int I1.Foo() { ... }
    
        string I2.Foo() { ... }
    }
   2. If one interface is updated to change a parameter for example, code using that interface will be easier to update, without breaking other interface implementations.
