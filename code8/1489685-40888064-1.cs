    public void TestSort()
    {
        var list = new List<MyObject>();
        list.Add(new MyObject("e", 1));
        list.Add(new MyObject("d", 4));
        list.Add(new MyObject("b", 2));
        list.Add(new MyObject("a", 1));
        list.Add(new MyObject("c", 3));
        list.Add(new MyObject("a", 4));
    
        Debug.WriteLine("unsorted");
        list.ForEach(obj => Debug.WriteLine(obj));
        list.Sort();
        Debug.WriteLine("sorted");
        list.ForEach(obj => Debug.WriteLine(obj));
    }
