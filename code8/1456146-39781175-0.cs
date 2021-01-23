    void SomeMethod()
    {
       try
       {
       }
       catch (Exception e)
       {
          throw new MyException(message, e);
       }
    }
    
    class MyException : Exception
    {
       public MyException(string message, Exception inner)
       : base(message, inner)
       {
       }
    }
