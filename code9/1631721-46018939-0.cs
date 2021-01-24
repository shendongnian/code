    using System;
    using MySystem; 
    
    namespace ConsoleApp1
    {
        class Program
        {
             public static void Main(string [] args)
            {
    
                Console.WriteLine("Hello world");      
                MyConsole.MyWriteLine("Hello world");
    
                //other way (then you wouldn't need using System and using MyNamespace)
    
                System.Console.WriteLine("Hello world01");
                MySystem.MyConsole.MyWriteLine("Hello world01");
              
            }
          
        }   
    }
    
    // I've created my own namespace
    namespace MySystem
    {
        class MyConsole
        {
           public static void MyWriteLine(string message)
            {
              //  some complex code that displays message on console(in short term)
            }
        }
       
    }
  
