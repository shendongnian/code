    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace Rextester
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                List<int>listPoints = new List<int>();
                List<int> listRanks = new List<int>();
        
                for (int i = 0; i < 1; i++)
                {
                    Console.ReadLine()
                        .Split()
                        .ToList()
                        .ForEach(s => {
    						listPoints.Add(int.Parse(s));
    						//or
    						listRanks.Add(int.Parse(s));
    					});
    				
    				foreach(string numero in Console.ReadLine().Split()) {
    					listPoints.Add(int.Parse(numero));
    					//or
    					listRanks.Add(int.Parse(numero));
    				}
                }
            }
        }
    }
