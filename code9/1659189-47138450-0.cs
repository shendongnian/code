    public static List<Numbers> setNumbers()
    {
        List<Numbers> num = new List<Numbers>();
        num.Add(new Numbers() { Column1 = 1, Column2 = 137 });
        num.Add(new Numbers() { Column1 = 1, Column2 = 143 });
        num.Add(new Numbers() { Column1 = 11, Column2 = 37 });
        num.Add(new Numbers() { Column1 = 11, Column2 = 46 });
        num.Add(new Numbers() { Column1 = 11, Column2 = 132 });
        num.Add(new Numbers() { Column1 = 46, Column2 = 65 });
        num.Add(new Numbers() { Column1 = 46, Column2 = 139 });
        num.Add(new Numbers() { Column1 = 69, Column2 = 90 });
        return num;
    }
    public static void group()
    {
        List<Numbers> numbers = setNumbers();
        var grouppedNumbers = numbers
            .GroupBy(x => x.Column1).ToList();
        grouppedNumbers.AddRange(grouppedNumbers.FirstOrDefault(x => x.First().Column1.Equals(46)).Select(s => new Numbers() { Column1 = 11, Column2 = s.Column2 }).GroupBy(g => g.Column1).ToList());
        grouppedNumbers.Remove(grouppedNumbers.FirstOrDefault(x => x.First().Column1.Equals(46)));
        
        foreach (var groups in grouppedNumbers)
        {
            Console.WriteLine(groups.First().Column1);
           foreach(var i in groups)
           {
               Console.WriteLine(i.Column1+" "+ i.Column2);
           }
        }
    }
