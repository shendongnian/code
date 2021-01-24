        var someObject = GetSomeObject();
        if (someObject is ISomeInterface)
        { 
          ((ISomeInterface)someObject).CallSomeMethod1();
          ((ISomeInterface)someObject).CallSomeMethod2();
          ((ISomeInterface)someObject).CallSomeMethod3();
        }
