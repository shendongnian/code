    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace FeelsBadMan
    {
        class Program
        {
            static void Main(string[] args)
            {
                while (true)
                {
                    try
                    {
                        Console.Write("Degree of a polynomial: ");
                        Int32 a = Convert.ToInt32(Console.ReadLine());
                        
                        Console.Write("Constant term : ");
                        Int32 n = Convert.ToInt32(Console.ReadLine());
    
                        List<Int32> array = new List<Int32>(a + 1);
    
                        for (Int32 i = 1; i <= a; ++i)
                        {
                            Console.Write("Input number x^{0}: ", i);
                            array.Add(Convert.ToInt32(Console.ReadLine()));
                        }
    
                        array.Insert(0,n);
    
                        Console.Write("Input x value: ");
                        Int32 x = Convert.ToInt32(Console.ReadLine());
    
                        Int32 result = array[a];
    
                        for (Int32 i = a - 1; i >= 0; --i)
                            result = (result * x) + array[i];
    
                        Console.Write("Result: {0}\n", result);
                        Console.ReadKey();
                    }
                    catch (OverflowException)
                    {
                        Console.WriteLine("Number out of scale! Try again.\n");
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Incorrect format! Try again.\n");
                    }
                }
            }
        }
    }
