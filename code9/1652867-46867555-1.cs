    using System;
    namespace ConsoleApplication1
    {
        class BusinessClass
        {
            static void Main(string[] args)
            {
                MarkupClass item1 = new MarkupClass();
                Console.WriteLine("what is the whole sale cost: ");
                decimal wholeSaleCost = decimal.Parse(Console.ReadLine());
    
                decimal markupPercent = item1.DoCalculations(wholeSaleCost);
                Console.WriteLine("Final % is :  {0}",markupPercent);    
            }
        }
        class MarkupClass
        {
            private decimal markupPercent = 1.05m;
            public decimal wholeSaleCost;
            public decimal DoCalculations(decimal wholeSaleCostIn)
            {
                while (markupPercent < 1.11m)
                {
                    decimal finalCost;
                    finalCost = wholeSaleCostIn * markupPercent;
                    Console.WriteLine("The wholesale price is: {0} and the final selling price is {1}", wholeSaleCostIn, finalCost);
                    markupPercent  += 0.01m;
                }
                return markupPercent;
    
            }
        }
    }
