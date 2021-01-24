    using System;
    using System.Collections.Generic;
    
    namespace ExtensionMethodTester
    {
      public class Program
      {
          public static void Main(string[] args)
          {
              List<string> myList = new List<string>();
              myList.MyTestMethod();
          }
      }
      
      public static class MyExtensions 
      {
        public static void MyTestMethod<T>(this List<T> list)
        {
             Console.WriteLine("Extension method called");
        }
      }
    }
