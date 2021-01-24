    void Main()
    {
        var sw = Stopwatch.StartNew();
        var amount = 1300000;
        //amount = 50000;
        var list1 = Enumerable.Range(0, amount).Select(i => new Demo(i)).ToList();
        var list2 = Enumerable.Range(10, amount).Select(i => new Demo(i)).ToList();
        sw.Stop();
        sw.Elapsed.Dump("Lists created");
        sw.Restart();
    
    
        var hs1 = new HashSet<Demo>(list1, new DemoComparer());
        var hs2 = new HashSet<Demo>(list2, new DemoComparer());
        sw.Stop();
        sw.Elapsed.Dump("Hashsets created");
        sw.Restart();
    
    //    var list3 = list1.Where(item1 => !list2.Any(item2 => item1.ID == item2.ID)).ToList();
    //    sw.Stop();
    //    sw.Elapsed.Dump("Any");
    //    sw.Restart();
    
        var list4 = list1.Except(list2, new DemoComparer()).ToList();
        sw.Stop();
        sw.Elapsed.Dump("Except");
        sw.Restart();
        hs1.ExceptWith(hs2);
        sw.Stop();
        sw.Elapsed.Dump("ExceptWith");
    
    //    list3.Count.Dump();
        list4.Count.Dump();
        hs1.Count.Dump();
    }
    
    // Define other methods and classes here
    class Demo
    {
        public Demo(int id)
        {
            ID = id;
            Name = id.ToString();
        }
        public int ID { get; set; }
        public string Name { get; set; }
    }
    
    class DemoComparer : IEqualityComparer<Demo>
    {
        public bool Equals(Demo x, Demo y)
        {
            return (x == null && y == null)
                || (x != null && y != null) && x.ID.Equals(y.ID);
        }
    
        public int GetHashCode(Demo obj)
        {
            return obj.ID.GetHashCode();
        }
    }
