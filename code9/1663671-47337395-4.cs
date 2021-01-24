    using System;
    using System.Linq;
    
    internal class Program
    {
        static string Capitalize(string oldSentence )
        {
            return
    
                // this will look at oldSentence char for char, we start with a
                // new string "" (the accumulator, short acc)
                // and inspect each char c of oldSentence
                // comment all the Console.Writelines in this function, thats 
                // just so you see whats done by Aggregate, not needed for it to 
                // work
                oldSentence 
                .Aggregate("", (acc, c) =>
                 {
                     System.Console.WriteLine("Accumulated: " + acc);
                     System.Console.WriteLine("Cecking:     " + c);
    
                     // if the accumulator is empty or the last character of 
                     // trimmed acc is a ".?!" we append the
                     // upper case of c to it
                     if (acc.Length == 0 || ".?!".Any(p => p == acc.Trim().Last())) // (*)
                         acc += char.ToUpper(c);
                     else
                         acc += c; // else we add it unmodified
    
                     System.Console.WriteLine($"After:      {acc}\n");
    
                     return acc; // this returns the acc for the next iteration/next c                  
                });
        }
    
        static void Main(string[] args)
        {
            Console.SetBufferSize(120, 1000);
            var oldSentence = "This is a testSentence. some occurences "
                + "need capitalization! for examlpe here. or here? maybe "
                + "yes, maybe not.";
            
            var newSentence = Capitalize(oldSentence);
    
            Console.WriteLine(new string('*', 80));
            Console.WriteLine(newSentence);
            Console.ReadLine();
        }
    }
