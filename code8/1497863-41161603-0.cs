    static void Main(string[] args)
    {
     List<int> list = new List<int>
      {
        1,
        2,
        7,
        10
      };
      int k = int.Parse(Console.ReadLine());
      list.Add(k);
      list.Sort();
    }
