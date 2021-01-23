    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace Marks
    {
        internal class Program
        {
            public static float AverageOfArrayList(ArrayList Array)
            {
                float AverageOfArrayList = 0;
                float Sum = 0;
    
                foreach (int item in Array)
                {
                    Sum += item;
                }
                AverageOfArrayList = Sum / Array.Count;
                return AverageOfArrayList;
            }
            public static ArrayList GetVariables(float CurrentAverage, double MissedAverage)
            {
                ArrayList o_NewMarksList = new ArrayList();
                if (CurrentAverage > MissedAverage)
                {
                    o_NewMarksList.Add(2);
                    for (int i = 1; MissedAverage < AverageOfArrayList(o_NewMarksList); i++)
                    {
                        o_NewMarksList.Add(2);
                    }
                }
    
                if (CurrentAverage < MissedAverage)
                {
                    o_NewMarksList.Add(5);
                    for (int i = 1; AverageOfArrayList(o_NewMarksList) < MissedAverage; i++)
                    {
                        o_NewMarksList.Add(5);
                    }
                }
                return o_NewMarksList;
            }
            static void Main(string[] args)
            {
                float CurrentAverage = 0;
                double MissedAverage = 0;
    
    
    
                Console.WriteLine("Enter how much marks have you got");
                int CountOfMarks = Convert.ToInt16(Console.ReadLine());
    
                Console.WriteLine("Enter the 1-st average");
                CurrentAverage = float.Parse(Console.ReadLine());
    
                Console.WriteLine("Enter the 2-nd average");
                MissedAverage = Convert.ToDouble(Console.ReadLine());
    
                ArrayList newList = GetVariables(CurrentAverage, MissedAverage);
                List<int> OutputArray = newList.Cast<int>().ToList();
    
                Console.WriteLine("Marks to add :");
    
                for (int OutputCounter = 0; OutputCounter < OutputArray.Count; OutputCounter++)
                {
                    Console.Write(OutputArray[OutputCounter] + " ");
                }
                Console.ReadKey();
            }
        }
    }
