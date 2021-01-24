    public  static void Main(string[] args)
        {
            var list = new List<int>();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Enter number " + i);
                int num = Convert.ToInt32(Console.ReadLine());
                list.Add(num); //adding the input number in list
            }
            Sum(list);           
        }
      private static void Sum(List<int> list)
      {
          int max =  list.Max();
          int min = list.Min();
          int sum = list.Where(x => x != max && x != min).Sum(); //taking the sum of all values exlcuding min and max
          Console.WriteLine("Sum is " + sum);
      }
