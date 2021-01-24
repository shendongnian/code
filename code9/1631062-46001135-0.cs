    class MyData
    {
         public string X {get; set;}
         public decimal Y {get; set;}
         public int Z {get; set;}
         public int E {get; set;}
    }
    IEnumerable<MyData> fetchedData = FetchMyData(...);
    // this is where you get the data from the table which creates for instance
    // your example.
