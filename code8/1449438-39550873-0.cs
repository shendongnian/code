    List<int> list = new List<int>
    {
        0,
        1,
        2,
        3,
        4
    };
    // get the object o(n)
    int tmp = list.IndexOf(2);
    // remove it
    list.RemoveAt(2);
    // add it to the end of list
    list.Add(tmp);
