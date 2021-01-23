    static int Max(int [] num)
	{
		int max = num[0];
		for(int i = 0; i < num.Length; i ++)
		{
			if(num[i] > max)
				max = num[i];
		}
		return max;
	}
    static int SecondMax(int[]a)
	{
        if(a.Length < 2) throw new Exception("....");
		int count = 0; 
		int max = Max(a);
		int[]b = new int[a.Length];
		for(int i = 0; i < a.Length; i ++)
		{
			if(a[i] == max && count == 0)
			{
				b[i] = int.MinValue; 
				count ++;
			}
			else b[i] = a[i];
		}
		return Max(b);
     }
