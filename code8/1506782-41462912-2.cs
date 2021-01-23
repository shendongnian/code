    public void ProductConverter(dynamic entity)
    {
       //Make sure the method exists. Or you will get an Exception.
       //The compiler can't warn you about this
       entity.SomeMethod1();
       entity.SomeMethod2();
    }
