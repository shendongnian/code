    public static void CreatGraph()
        {
            var raw_txt = System.IO.File.ReadAllLines(@"D:\\Projects\\GraphData.csv");
            var v2 = from p in raw_txt.Skip(1)
                     select new GraphsData
                     {
                         XAxis = double.Parse((p.Split(','))[7]),
                         YAxis = double.Parse((p.Split(','))[8])
                     };
            foreach (var item in v2)
            {
                Console.WriteLine(item.XAxis + " | " + item.YAxis);    
            }
            
        }
