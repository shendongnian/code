    using (var parser = new ChoCSVReader("EmpDuplicates.csv").WithFirstLineHeader())
    {
        foreach (dynamic c in parser.GroupBy(r => r.Id).Where(g => g.Count() > 1).Select(g => g.FirstOrDefault()))
            Console.WriteLine(c.DumpAsJson());
    }
