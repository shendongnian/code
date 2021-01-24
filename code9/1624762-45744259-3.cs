      //Implementation 1: It will throw an error when FooClass is checked internally
      var factory = new AirplaneFactory(new[] 
      { 
           typeof(F15), 
           typeof(F16), 
           typeof(Boeing747), 
           typeof(FooClass) 
       });
      //Implementation 2:
      AirplaneFactory factory = new AirplaneFactory();
      factory.AddType<F15>();
      factory.AddType<F16>();
      factory.AddType<Boeing747>();
      //factory.AddType<FooClass>(); //This line would not compile.
