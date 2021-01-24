    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                double l_dblAnswer = 0;
                double l_dblRes = 0;
                Console.WriteLine("Enter numbers seperated by commas.");
                string numbers = Console.ReadLine();
                string[] l_strNumbers = numbers.Split(',');
                Console.WriteLine("Select Option 1. Addition, 2. Multiplication");
                string l_strOption = Console.ReadLine();
                switch(l_strOption)
                {
                    case "1":
                        foreach (string l_strNum in l_strNumbers)
                        {
                             if(double.TryParse(l_strNum, out l_dblRes ) )
                            {
                                l_dblAnswer += l_dblRes;
                            }
                        }
                        break;
                    case "2":
                        foreach (string l_strNum in l_strNumbers)
                        {
                            l_dblAnswer = 1;
                            if (double.TryParse(l_strNum, out l_dblRes))
                            {
                                l_dblAnswer *= l_dblRes; 
                            }
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid Choice.");
                        break;
                }
                Console.WriteLine("Answer is " + l_dblAnswer.ToString());
                Console.ReadLine(); 
            }
        }
    }
