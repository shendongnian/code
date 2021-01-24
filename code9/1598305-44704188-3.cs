    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    namespace ConsoleApplication1
    {
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<PriceObject> list1 = new HashSet<PriceObject>();
            HashSet<PriceObject> list2 = new HashSet<PriceObject>();
            using (StreamReader reader = File.OpenText(args[0]))
            {
                string line = reader.ReadLine(); // this will remove the header row
                while (!reader.EndOfStream)
                {
                    line = reader.ReadLine();
                    if (String.IsNullOrEmpty(line))
                        continue;
                    // add each line to our list
                    list1.Add(new PriceObject(line, ','));
                }
            }
            using (StreamReader reader = File.OpenText(args[1]))
            {
                string line = reader.ReadLine(); // this will remove the header row
                while (!reader.EndOfStream)
                {
                    line = reader.ReadLine();
                    if (String.IsNullOrEmpty(line))
                        continue;
                    // add each line to our list
                    list2.Add(new PriceObject(line, '|'));
                }
            }
            // merge the two hash sets, order by price
            list1.UnionWith(list2);
            List<PriceObject> output = list1.ToList();
            output.OrderByDescending(x => x.price).ToList();
            // display output here, e.g. define your own ToString method, etc
            foreach (var item in output)
            {
                Console.WriteLine(item.ToString());
            }
            Console.ReadLine();
        }
    }
    }
