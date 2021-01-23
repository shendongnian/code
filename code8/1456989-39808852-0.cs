    public class MyCustomException : Exception
    {
       //This is like you have now
       public MyCustomException() { }
       //This is if you want to have different messages
       public MyCustomException(string message)  : base(message{ }
       //This is if you want to have different data to add (don't use object but a custom type
       public MyCustomException(object yourObject)
       {
          YourObject = yourObject;
       }
       public object YourObject { get; set; }
    }
