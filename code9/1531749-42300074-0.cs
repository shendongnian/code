    MyClass mc = new MyClass(); // create new instance of MyClass and store it in the "mc" variable
    mc // Direct call to the instance
        .Strings // Direct call to MyClass Strings property
             // inside Strings property :
             // return _strings ?? new List<string>();
             // meaning that if "_strings" member field is null
             // return new instance of that property's type
        .Add("abc"); // adds "abc" to the "forgotten" instance of List<string>
