    class Program
    {
        static void Main(string[] args)
        {
            List<List1Class> listClass = new List<List1Class>();
            listClass.Add(new List1Class { ObjectName = "obj1" });
            listClass.Add(new List1Class { ObjectName = "obj2" });
            listClass.Add(new List1Class { ObjectName = "obj3" });
            listClass.Add(new List1Class { ObjectName = "obj4" });
            List<string> listString = new List<string>();
            listString.Add("obj2");
            listString.Add("obj4");
            listString.Add("obj5");
            var filterlist = listClass.Where(l => !listString.Contains(l.ObjectName)).ToList();
        }
    }
