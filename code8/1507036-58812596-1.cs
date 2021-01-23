    SortedList<int, string> sortedList = new SortedList<int,string>();
    sortedList.Add(1, "one");
    sortedList.Add(2, "two");
    sortedList.Add(4, "four");
    sortedList.Add(50, "fifty");
    int currentIndex = sortedList.Keys.IndexOf(2);
    Console.WriteLine(sortedList.Keys[currentIndex+1]);
    Console.WriteLine(sortedList.Values[currentIndex+1]);
