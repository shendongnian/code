    namespace ClassesDemo
    {
       public class Parent
       {
           public string item{get;set;}
       }
     
       private class Child : Parent
       {
       }
    }
    
    namespace MainProgram
    {
       class Program
       {
          public static void ConsoleWrite(Parent pitem)
          {
              Console.Write(pitem.item);
          }
    
          public static void Main()
          {
              ConsoleWrite(new Child(){item = "foo"});
          }
       }
    }
