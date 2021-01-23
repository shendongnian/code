    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace most_frequent_int
    {
    class Program
    {
        static void Main(string[] args)
        {
            string result = mostFreq(new int[] {1,5,2,5,24,6,5});
            Console.WriteLine(result);
        }
    
        static string mostFreq(int[] number)
        {
            int element = 0;
            int count = 0;
    
            for (int j = 0; j < number.Length; j++)
            {
                int tempElement = number[j];
                int tempCount = 0;
    
                for (int p = 0; p <number.Length; p++)
                {
                    if (number[p] == tempElement)
                    {
                        tempCount++;
                    }
                    if (tempCount > count)
                        element = tempElement;
                    {
                        count = tempCount;
                    }
                }
            }
    return "The most frequent element is: " + element + " and appears " + count + " times."        
        }
    
    }
