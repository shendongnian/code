    using System;
    using System.Linq;
    namespace ConsoleApp1
    {
        public class Program
        {
            static void Main()
            {
                Console.WriteLine(test1(1));
                Console.WriteLine(test2(1));
                Func<int, int[]> getDigits = v => v.ToString().Select(Convert.ToInt32).ToArray();
                Func<int[], int> getDigitSquareSum = x => (int)x.Select(d => Math.Pow(d, 2)).Sum();
                Console.WriteLine(test3(1, getDigits, getDigitSquareSum));
            }
            static int test1(int value) // Use local Func<>
            {
                Func<int, int[]> getDigits = v => v.ToString().Select(Convert.ToInt32).ToArray();
                Func<int[], int> getDigitSquareSum = x => (int)x.Select(d => Math.Pow(d, 2)).Sum();
                var a = getDigits(value);
                var b = getDigitSquareSum(a);
                return b;
            }
            static int test2(int value) // Use local function.
            {
                int[] digits(int v) => v.ToString().Select(Convert.ToInt32).ToArray();
                int digitSquareSum(int[] x) => (int) x.Select(d => Math.Pow(d, 2)).Sum();
                var a = digits(value);
                var b = digitSquareSum(a);
                return b;
            }
            // Pass in Func<>
            static int test3(int value, Func<int, int[]> getDigits, Func<int[], int> getDigitSquareSum)
            {
                var a = getDigits(value);
                var b = getDigitSquareSum(a);
                return b;
            }
        }
    }
                                                      
