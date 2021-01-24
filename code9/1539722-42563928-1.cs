    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace PartitionAndAllocateTEst
    {
        class Program
        {
            static void Main(string[] args)
            {
                var rand = new Random();
                int desiredTotal = 100;
                int partitions = 5;
    
                for (int i = 0; i < 10; i++)
                {
                    List<int> result = GetRandomCollection(rand, desiredTotal, partitions);
                    Console.WriteLine(string.Join(", ", result.Select(r => r.ToString()).ToArray()));
                }
            }
    
            private static List<int> GetRandomCollection(Random rand, int desiredTotal, int partitions)
            {
                // calculate the weights
                var weights = new List<double>();
                for (int i = 0; i < partitions; i++)
                {
                    weights.Add(rand.NextDouble());
                }
                var totalWeight = weights.Sum();
    
                // allocate the integer total by weight
                // http://softwareengineering.stackexchange.com/questions/340393/allocating-an-integer-sum-proportionally-to-a-set-of-reals/340394#340394
                var result = new List<int>();
                double allocatedWeight = 0;
                int allocatedCount = 0;
                foreach (var weight in weights)
                {
                    var newAllocatedWeight = allocatedWeight + weight;
                    var newAllocatedCount = (int)(desiredTotal * (newAllocatedWeight / totalWeight));
                    var thisAllocatedCount = newAllocatedCount - allocatedCount;
                    allocatedCount = newAllocatedCount;
                    allocatedWeight = newAllocatedWeight;
    
                    result.Add(thisAllocatedCount);
                }
    
                return result;
            }
        }
    }
