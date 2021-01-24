    public static int[] twodigi(int number)
    {
        Random random = new Random();    
        int[] a = new int[number];
		for (int i = 0; i < number; i++)
        {         
            a[i] = random.Next(10, 100);
        }
          return a.GroupBy(v => v).Select(x=> x.Key + x.Count()).ToArray();
    }
