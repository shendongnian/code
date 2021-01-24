    class MyComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            // your logic here
        }
    }
    // ...
    IEnumerable<string> myListOfStrings = ...;
    myListOfStrings.OrderBy(x => x, new MyComparer());
