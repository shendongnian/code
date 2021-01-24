    using System;
    using System.Collections.Generic;
    
    public class Program
    {
        public static void Main()
        {
            // name, percentage
            Dictionary<string, double> distribution = new Dictionary<string,double>();
    
            // name, amount if one more were to be distributed
            Dictionary<string, int> dishedOut = new Dictionary<string, int>();
    
            //Initialize
            int numToGive = 20;
            distribution.Add("a", 0.50);
            distribution.Add("b", 0.25);
            distribution.Add("c", 0.25);
    
            foreach (string name in distribution.Keys)
                dishedOut.Add(name, 1);
    
            for (int i = 0; i < numToGive; i++)
            {
                //find the type with the lowest weighted distribution
                string nextUp = null;
                double lowestRatio = double.MaxValue;
                foreach (string name in distribution.Keys)
                    if (dishedOut[name] / distribution[name] < lowestRatio)
                    {
                        lowestRatio = dishedOut[name] / distribution[name];
                        nextUp = name;
                    }
                //distribute it
                dishedOut[nextUp] += 1;
                Console.WriteLine(nextUp);
            }
    
            Console.ReadLine();
        }
    }
