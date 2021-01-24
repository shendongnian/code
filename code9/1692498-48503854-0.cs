    public class MyClass
    {
       public MyClass(XElement elem) 
       {
           // your constructor logic
       }
       public static MyClass Create(XElement elem)
       {
          return new MyClass(elem);
       }
    }
