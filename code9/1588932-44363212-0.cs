    using System;
    
    namespace ValueTupleTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                (char letterA, char letterB) _test = ('A','B');
                Console.WriteLine($"Letter A: '{_test.letterA}', Letter B: '{_test.letterB}'");
                
                if (_test.letterA == 'A' && _test.letterB == 'B')
                {
                    Console.WriteLine("Case A ok.");
                }
                else if (_test.letterA == 'D' && _test.letterB == '\0')
                {
                    Console.WriteLine("Case D ok.");
                }
    
            }
        }
    }
