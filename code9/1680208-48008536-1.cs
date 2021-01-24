    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System;
    
    namespace StackOverFlowHelp
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.Write("Enter the Amounts Separated By space : ");
                var listItems = Console.ReadLine();
                Console.Write("Enter the target : ");
                var target = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
    
                List<Int32> numbers = listItems.Split(' ').Select(x => Convert.ToInt32(x)).ToList();
                if (numbers.Count <= 1)
                {
                    Console.WriteLine("The list must contain at-least 2 numbers");
                }
                else
                {
                    var currentSum = numbers.Sum();
                    if (currentSum == target)
                    {
                        Console.WriteLine("SUM of List " + string.Join(" ", numbers) + " already matches the target " + target + ". No number has been removed.");
                    }
                    else if (currentSum < target)
                    {
                        Console.WriteLine("SUM of List " + string.Join(" ", numbers) + " is smaller than the target " + target + ". No number can been removed.");
                    }
                    else
                    {
                        numbers.Sort();
                        var incrementalSum = 0;
                        var qualifiedIndex = 0;
                        for (int i = 0; i < numbers.Count; i++)
                        {
                            incrementalSum += numbers[i];
                            if (incrementalSum == target)
                            {
                                /*Remove the numbers after index value*/
                                qualifiedIndex = i + 1;
                            }
                            else if (incrementalSum > target)
                            {
                                /*Remove the numbers from index value*/
                                qualifiedIndex = i;
                            }
                            if (qualifiedIndex > 0)
                            {
                                /*We are ready with our results*/
                                Console.WriteLine("SUM of List " + string.Join(" ", numbers.Take(qualifiedIndex)) + " is closest to the target " + target + ". Following number can been removed: " + string.Join(" ", numbers.Skip(qualifiedIndex).Take(numbers.Count - qualifiedIndex)));
                                break;
                            }
                        }
                        if (qualifiedIndex == 0)
                        {
                            Console.WriteLine("Could not find any number to remove.");
                        }
                    }
                }
                Console.WriteLine();
                Console.WriteLine("Press Any Key to Exit.....");
                Console.Read();
            }
        }
    }
