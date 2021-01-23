    List<Tuple<string, string>> list1 = new List<System.Tuple<string, string>>();
    list1.Add(new Tuple<string, string>("1", "data1"));
    list1.Add(new Tuple<string, string>("2", "data2"));
    list1.Add(new Tuple<string, string>("2", "data3"));
    list1.Add(new Tuple<string, string>("2", "data3")); //duplicate
    list1.Add(new Tuple<string, string>("3", "data3"));
    
    var hs  = new HashSet<Tuple<string, string>>(list1);
    
    var toCheck = new Tuple<string,string>("2","data3");
    Console.WriteLine(hs.Contains(toCheck)); //True
    toCheck = new Tuple<string,string>("2","data7");
    Console.WriteLine(hs.Contains(toCheck)); //False
