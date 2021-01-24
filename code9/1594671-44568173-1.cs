     using System;
    class Program
     {
    static void Main()
    {
    const string input = "key logger";
    Console.WriteLine("::BEFORE::");
    Console.WriteLine(input);
    string output = input.Replace("key ", "keyword ");
    Console.WriteLine("::AFTER::");
     Console.WriteLine(output);    
     }
     }
