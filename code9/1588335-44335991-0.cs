    interface I1
    {
       void DoIt();
    }
    
    
    interface I2
    {
       void DoIt();
    }
    
    
    class A : I1, I2
    {
       public void DoIt()
       {
          // do sth
       }
    }
    
    // Note: All v-tables point to the same implementation in A
    I1 test1 = new A();
    test1.DoIt(); // => lookup in I1's v-table
    I2 test2 = (I2)test1;
    test2.DoIt(); // => Lookup in I2's v-table
    A a = (A)test2;
    a.DoIt(); // => Lookup in A's v-table
