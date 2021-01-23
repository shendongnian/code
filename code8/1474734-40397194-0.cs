    using (var myWriter1 = new StreamWriter(resultpath, true))
    {
        List<string> a = File.ReadAllLines(path).ToList();
        List<string> b = File.ReadAllLines(newPath).ToList();
        int coincidences=0;
        foreach (string s in a)
        {
            Console.WriteLine(s);
            if (!b.Contains(s))
            {
                myWriter1.WriteLine(s);
                coincidences++;
            }
        }
        if (coincidences == 0)
        {
             myWriter1.WriteLine("Der er ikke nogen udmeldinger idag", true);
        }
    }
