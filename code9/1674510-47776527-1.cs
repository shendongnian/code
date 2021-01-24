    public void TestMethod()
    {
        List<Tuple<double, double, double>> list = new List<Tuple<double, double, double>>();
        list.Add(new Tuple<double, double, double>(1, 2, 3));
        list.Add(new Tuple<double, double, double>(1, 2, 5));
        list.Add(new Tuple<double, double, double>(8, 2, 3));
        list.Add(new Tuple<double, double, double>(1, 5, 3));
        var x = GetIt(1, list);
        var y = GetIt(1, 2, list);
    }
    public List<double> GetIt(double d, List<Tuple<double, double, double>> list)
    {
        return (from a in list
                where a.Item1 == d
                select a.Item2).Distinct().ToList();
    }
    
    public List<double> GetIt(double d, double e, List<Tuple<double, double, double>> list)
    {
        return (from a in list
                where a.Item1 == d && a.Item2 == e
                select a.Item3).Distinct().ToList();
    }
