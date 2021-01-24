    public static ConcurrentDictionary<string, Country> countries = new ConcurrentDictionary<string, Country>();
    public void Main()
    {
        Country poland = new Country { Name = "Poland", Capital = "Krakow" };
        countries[poland.Name] = poland; 
        // oops lets update the right capital:
        poland.Capital = "Warsaw";
        myList.AddOrUpdate(poland.Name, poland, (key, existingVal) => 
                                             {
                                                 Console.WriteLine($"The old value was: '{existingVal}'");  
                                                 return existingVal; 
                                             });
    }
    //Output: The old value was: 'Krakow'
