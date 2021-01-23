    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace E03_pt2_3
    {
        class Program
        {
            static void Main(string[] args)
            {
                int numberOfDrawers = 0;
                string deskWoodType = "o";
                double cost = 0;
                drawersMeth(out numberOfDrawers);
                woodTypeMeth(out deskWoodType);
                CalculateCostMeth(ref deskWoodType, ref numberOfDrawers, out cost);
                OutPutCostMeth(numberOfDrawers, deskWoodType, cost);
            }//end main
            private static void drawersMeth(out int numberOfDrawers)
            {
                int numOfDrawers;
                Console.WriteLine("Enter the number of desk drawers");
                numOfDrawers = Convert.ToInt16(Console.ReadLine());
                numberOfDrawers = numOfDrawers;
            }//end drawersMeth
            private static string woodTypeMeth(out string deskWoodType)
            {
                Console.WriteLine("Enter the desk wood type. (ex. type mahogany, oak, or pine)");
                deskWoodType = Convert.ToString(Console.ReadLine());
                switch (deskWoodType)
                {
                    case "mahogany":
                        {
                            deskWoodType = "m";
                            break;
                        }
                    case "oak":
                        {
                            deskWoodType = "o";
                            break;
                        }
                    case "pine":
                        {
                            deskWoodType = "p";
                            break;
                        }
                    default:
                        {
                            deskWoodType = "error";
                            break;
                        }
                }
                return deskWoodType;
            }// end woodTypeMeth
            private static double CalculateCostMeth(ref string deskWoodType,ref int numberOfDrawers, out double cost)
            {
                double pine = 100;
                double oak = 140;
                double other = 180;
                double surchage = 30;
                if (deskWoodType == "p")
                    cost = pine + (numberOfDrawers * surchage);
                else if (deskWoodType == "o")
                    cost = oak + (numberOfDrawers * surchage);
                else
                    cost = other + (numberOfDrawers * surchage);
                return cost;
            }// end CalculateCostMeth
            private static void OutPutCostMeth(int numberOfDrawers, string deskWoodType, double cost)
            {
                double totalCost = cost;
                Console.WriteLine("The number of drawers is {0}", numberOfDrawers);
                Console.WriteLine("The wood type you have selected is ", deskWoodType);
                Console.WriteLine("The total cost is {0:c2}", totalCost);
            }//end outputCost
        }//end class
    }//end nameSpace
