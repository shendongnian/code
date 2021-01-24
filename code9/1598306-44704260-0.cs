    using System;
    using System.Collections.Generic;
    
    class Program
    {
        class entry
        {
            public string origin;
            public string destination;
            public DateTime time;
            public double price;
        }
    
        static void Main(string[] args)
        {
            List<entry> data = new List<entry>();
    
            //parse the input files and add the data to a list
            ParseFile(data, args[0], ',');
            ParseFile(data, args[1], '|');
    
            //sort the list (by price first)
            data.Sort((a, b) =>
            {
                if (a.price != b.price)
                    return a.price > b.price ? 1 : -1;
                else if (a.origin != b.origin)
                    return string.Compare(a.origin, b.origin);
                else if (a.destination != b.destination)
                    return string.Compare(a.destination, b.destination);
                else
                    return DateTime.Compare(a.time, b.time);
            });
    
            //remove duplicates (list must be sorted for this to work)
            int i = 1;
            while (i < data.Count)
            {
                if (data[i].origin == data[i - 1].origin
                    && data[i].destination == data[i - 1].destination
                    && data[i].time == data[i - 1].time
                    && data[i].price == data[i - 1].price)
                    data.RemoveAt(i);
                else
                    i++;
            }
    
            //print the results
            for (i = 0; i < data.Count; i++)
                Console.WriteLine("{0}->{1}->{2:yyyy-MM-dd HH:mm}->${3}",
                    data[i].origin, data[i].destination, data[i].time, data[i].price);
    
            Console.ReadLine();
        }
    
        private static void ParseFile(List<entry> data, string filename, char separator)
        {
            using (System.IO.FileStream fs = System.IO.File.Open(filename, System.IO.FileMode.Open))
            using (System.IO.StreamReader reader = new System.IO.StreamReader(fs))
                while (!reader.EndOfStream)
                {
                    string[] line = reader.ReadLine().Split(separator);
                    if (line.Length == 4)
                    {
                        entry newitem = new entry();
                        newitem.origin = line[0];
                        newitem.destination = line[1];
                        newitem.time = DateTime.Parse(line[2]);
                        newitem.price = double.Parse(line[3].Substring(line[3].IndexOf('$') + 1));
                        data.Add(newitem);
                    }
                }
        }
    }
