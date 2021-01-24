    List<DateTime> list = new List<DateTime>();
    list.Add(Convert.ToDateTime("29 Jan"));
    list.Add(Convert.ToDateTime("25 Jan"));
    list.Add(Convert.ToDateTime("20 Jan"));
    list.Add(Convert.ToDateTime("10 Jan"));
    list.Add(Convert.ToDateTime("3 Jan"));
    var comparer = Comparer<DateTime>.Create((x, y) => -x.CompareTo(y)); // notice negative
    var search = Convert.ToDateTime("2 Jan");
    var find = list.BinarySearch(search, comparer);
    if (find < 0) find = ~find - 1; // minus 1 because ordered by descending
    Console.WriteLine(find);
