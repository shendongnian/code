    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace Test
    {
        public static class GenericExtensions
        {
            public static int IndexExcludingValue<T>(this IEnumerable<T> test, T valueToFind, T valueToExclude) where T : struct
            {
                return test.Where(z => !Equals(z, valueToExclude))
                    .Select((value, index) => new { value, index })
                    .FirstOrDefault(z => Equals(z.value, valueToFind))?.index ?? -1;
            }
    
            public static T[] FastReplaceFirstMatch<T>(this T[] test, T valueToFind, T valueToReplace) where T : struct
            {
                var hasBeenReplaced = false;
    
                var index = Array.FindIndex(test, z => Equals(z, valueToFind));
    
                if (index != -1)
                {
                    test[index] = valueToReplace;
                }
    
                return test;
            }
    
    
            public static IEnumerable<T> ReplaceFirstMatch<T>(this IEnumerable<T> test, T valueToFind, T valueToReplace) where T : struct
            {
                var hasBeenReplaced = false;
    
                return test
                    .Select(value =>
                        {
                            if (!hasBeenReplaced && Equals(value, valueToFind))
                            {
                                hasBeenReplaced = true;
                                value = valueToReplace;
                            }
                            return value;
                        });
            }
        }
    
        public class Program
        {
            private static int[] bob = { 1, 2, 3, 4, 0, 5, 0, 6, 7 };
    
            static void Main(string[] args)
            {
                Console.WriteLine(bob.IndexExcludingValue(6, 0));
                Console.WriteLine(string.Join(",", bob.ReplaceFirstMatch(6, 8).ToArray()));
                Console.WriteLine(string.Join(",", bob.FastReplaceFirstMatch(6, 10)));
    
                Console.ReadLine();
            }
        }
    }
