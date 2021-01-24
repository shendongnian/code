    for(int i=0; i<list.Count-1; i++)
    {
        for(int j=i+1;j<list.Count;j++)
        {
            if(list[i]+list[j] == sum)
            {
                return Tuple.Create(i, j);
            }
        }
    }
    return null;
