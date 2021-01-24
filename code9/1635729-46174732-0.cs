    public method<T>(T param)
    {
        if(param.GetType() == typeof(Class1))
        {
          //Do stuff for Class1
          Console.WriteLine("Class1");
        }
        else if (param.GetType() == typeof(Class2))
        {
          //Do stuff for Class2
          Console.WriteLine("Class2");
        }
    }
