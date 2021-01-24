    using System;
    
    class MyClass
    {
    }
    
    class MyClass2: MyClass
    {
    }
    namespace Appl
    {
       class Program
       {
          static void Main(string[] args)
          {
             System.Console.WriteLine(typeof(MyClass2).BaseType.Name);
          }
       }
    }
