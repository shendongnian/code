    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public class Program
    {
        public static void Main()
        {
            // name, percentage
            Dictionary<string, double> distribution = new Dictionary<string,double>();
    
            // name, weighted amount if one more were to be distributed
            Dictionary<string, double> dishedOut = new Dictionary<string, double>();
    
            //Initialize
            int numToGive = 20;
            distribution.Add("a", 0.50);
            distribution.Add("b", 0.25);
            distribution.Add("c", 0.25);
    
            foreach (string name in distribution.Keys)
                dishedOut.Add(name, 1 / distribution[name]);
    
            for (int i = 0; i < numToGive; i++)
            {
                //find the type with the lowest weighted distribution
                string nextUp = dishedOut.Aggregate((l, r) => l.Value < r.Value ? l : r).Key;
                    
                //distribute it
                dishedOut[nextUp] += 1 / distribution[nextUp];
                Console.WriteLine(nextUp);
            }
    
            Console.ReadLine();
        }
    }
