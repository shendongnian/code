    using System;
    using System.Collections.Generic;  // for Dictionary
    using System.Linq;  // for FirstOrDefault
    using System.Text.RegularExpressions;  // for RegEx
    
    namespace ConsoleApplication
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                Console.WriteLine("Hello World!");
    
                var input = "What's the meaning of Stretch Hood";
                		var functions = new Dictionary<Regex, Action>
                        {
                            {new Regex("/^(What is|What's|Could you please tell me|Could you please give me) the meaning of (TF|FFS|SF|SHF|FF|Tube Film|Shrink Film|Stretch Hood|Stretch Hood Film|Flat Film)$/"),
                                 itemsIdentification},
                            {new Regex("/^(What is|What's|Could you please tell me|Could you please give me) the (stock|inventory) of ML$/"),
                                 mlSOH},
                            {new Regex("/^(What is|What's) (our|the) (stock|inventory|SoH) of (TF|FFS|SF|SHF|FF|Tube Film|Shrink Film|Stretch Hood|Stretch Hood Film|Flat Film)$/"),
                                 SoH},
                            {new Regex("/^(What is|What's|Calculate|How much is) ([\w.]+) (\+|and|plus|\-|less|minus|\*|\x|by|multiplied by|\/|over|divided by) ([\w.]+)$/"),
                                 math},
                        };
                functions.FirstOrDefault(f => f.Key.IsMatch(input)).Value?.Invoke();    // This will execute the first Action found wherever the input matching the RegEx, the ?. means if not null ([Null-conditional Operators][1])
    // or 
                Action action;
                action = functions.FirstOrDefault(f => f.Key.IsMatch(input)).Value;
                if (action != null)
                {
                    action.Invoke();
                }
                else
                {
                    // No function with that name
                }
            }
    
            public static void itemsIdentification()
            {
            Console.WriteLine("Fn 1");
            }
    
            public static void mlSOH()
            {
            Console.WriteLine("Fn 2");
            }
            public static void SoH()
            {
            
            }
            public static void math()
            {
            
            }
        }
    }
