    int[] indeces = new int[itemcost.Length];
        
    for (int i = 0; i < itemcost.Length; i++)
    {
       indeces[i] = i;
    }
        
    Array.Sort(itemcost, indeces);
