    static void Main(string[] args)
    {
       ArrayList list = new ArrayList();
       list.Add(1);
       list.Add(2);
       list.Add(3);
       int total = 0;
       foreach(object item in list)
          total += (int)item; // without casting, compiler never knows item is int
       Console.WriteLine("Total = {0}", total);
    }
