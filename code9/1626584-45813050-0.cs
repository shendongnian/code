        var path = @"C:\Users\admin\Desktop\test.txt";
        List<string> list = File.ReadAllLines(path).ToList();
        list = list.OrderBy(x => Convert.ToInt32(x.Split('|')[0])).ToList();
        
        for(var i = 0; i < list.Count; i++)
        {
            Console.WriteLine(list[i]);
        }
