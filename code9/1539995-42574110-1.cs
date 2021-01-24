        var someObject = GetSomeObject();
        if (someObject is ISomeInterface)
        { 
          var someObjectCasted = (ISomeInterface)someObject;
          someObjectCasted.CallSomeMethod1();
          someObjectCasted.CallSomeMethod2();
          someObjectCasted.CallSomeMethod3();
        }
