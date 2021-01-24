    int[] array = new int[80];
    for (int i = 0; i < 80; i++)
    {
        int val = 0;
        if (i < 20)
        {
            val = 1;
        }
        array[i] = val;            
    }
    Random rnd = new Random();
    int[] shuffledArray = array.OrderBy(x => rnd.Next()).ToArray();
