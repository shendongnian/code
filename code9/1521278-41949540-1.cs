    using System;
    
    public class Example
    {
       public static void Main()
       {
        string toBeReplaced = "Hi how are you? I'm ** fine.";        
        Console.WriteLine(toBeReplaced.Replace("*",""));
       }
    }
