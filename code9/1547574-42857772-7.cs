    // let's create inifite number of random values:
    // note that the Random instance needs to be created only once,
    // so it's put into a field.
    private Random random = new Random();
    public IEnumerable<int> InfiniteRandomValues()
    {
      while (true)
      {
        yield return random.Next(1, 100);
      }
    }
    public int[] GetUniqueRandomValues(int numberOfValues)
    {
      return InfiniteRandomValues()
        // only uninque values
        .Distinct()
        // generate the requested number of distinct values
        .Take(numberOfValues)
        // put it into an array.
        .ToArray();
    } 
