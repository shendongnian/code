    void MyFunction (string myText)
    {
        MyFunction (myText, 0); 
        // this works because C# will infer T as being int
    }
    
    void MyFunction<T> (string myText, T optionalGenericParameter)
    {
      //Do something
    }
    
    /* usage example:
    MyFunction("foo");
    MyFunction("bar", new Tuple<string, int>("yay", 113));
    // C# will infer that T is Tuple<string, int> here.
    */
