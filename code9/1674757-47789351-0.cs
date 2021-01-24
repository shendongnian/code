    namespace MultiTag_Simulation_ConsoleApp
    {
        using System;
        using System.IO;
        using System.Linq;
        using System.Threading.Tasks;
    
        internal static class Program
        {
            internal static void Main()
            {
                Parallel.ForEach(
                    File.ReadLines("2Tags_Points.txt").Select(line => line.Split('\t')),
                    parts =>
                        {
                            var w = Convert.ToDouble(parts[1]);
                            var x = Convert.ToDouble(parts[2]);
                            Console.WriteLine("Tag1 x:" + w + "\t" + "Tag1 y:" + x);
    
                            var y = Convert.ToDouble(parts[4]);
                            var z = Convert.ToDouble(parts[5]);
                            Console.WriteLine("Tag2 x:" + y + "\t" + "Tag2 y:" + z);
                        });
            }
        }
    }
