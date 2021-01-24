    List<int> list = new List<int>();
    list.Add(3);
    list.Add(5);
    list.Add(6);
    list.Add(-3);
    list.Add(5);
    
    int sum = 0;
    for (int i = 0; i < list.Count; i++)
    {
        if(i % 3 == 0) // sum every third number
        {
            sum += list[i];
        }
    }
