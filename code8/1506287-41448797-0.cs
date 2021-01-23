    using System.Collections.Concurrent;
    using System.IO;
    using System.Linq;
    
    namespace FileSplitter
    {
        internal static class Program
        {
            internal static void Main(string[] args)
            {
                var input = File.ReadLines("in.csv").Skip(1);
    
                var partitioner = Partitioner.Create(input);
                var partitions = partitioner.GetPartitions(4);
    
                for (int i = 0; i < partitions.Count; i++)
                {
                    var enumerator = partitions[i];
    
                    using (var stream = File.OpenWrite($"out-{i + 1}.csv"))
                    {
                        using (var writer = new StreamWriter(stream))
                        {
                            while (enumerator.MoveNext())
                            {
                                writer.WriteLine(enumerator.Current);
                            }
                        }
                    }
                }
            }
        }
    }
