    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                /*pseudocode
            Program : CarParkCalc3
                 * HOURLY_RATE=2.50
                 * MAX_FREE=20.00
                 * int[]hoursArray 
                 * parkFee = HOURLY_RATE * hoursArray
                 * IF parkTime > MAX_FEE THEN
                 *      OUTPUT MAX_FEE
                 * ELSE
                 *      OUTPUT parkFee
                 * ENDIF
            */
    
    
                const decimal HOURLY_RATE = 2.50m;
                const decimal MAX_FEE = 20m;
                decimal parkFee = 0;
                int[] hoursArray = { 8, 24, 9, 7, 6, 12, 10, 11, 23, 1, 2, 9, 8, 8, 9, 7, 9, 15, 6, 1, 7, 6, 12, 10, 11, 23, 1, 2, 9, 8 };
                decimal total = 0;
                double average = 0;
    
                Console.WriteLine("Hours  Park fee");
                for (int index = 0; index < hoursArray.Length; index++)
                {
    
    
    
                    {
                        parkFee = HOURLY_RATE * hoursArray[index];
                        total += parkFee;
                        if (parkFee > MAX_FEE)
                        {
                            Console.WriteLine("{0,6}   {1,9} ", hoursArray[index], MAX_FEE.ToString("N"));
                        }
                        else
                        {
                            Console.WriteLine("{0,6}   {1,9} ", hoursArray[index], parkFee.ToString("N"));
                        }
    
                    }
    
                }
    
                
                
    
                average = (double)total / hoursArray.Length;
                Console.WriteLine("Total = " + total);
                Console.WriteLine("Average = " + average.ToString("N2"));
                Console.ReadKey();
            }
        }
    }
