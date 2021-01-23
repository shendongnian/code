    for (int i = 0; i < listN.Count; i++)
    {
        if (listM.Remove(listN[i]))
        {
            listN.RemoveAt(i--);
        }
    }
    for (int i = 0; i < listM.Count; i++)
    {
        if (listN.Remove(listM[i]))
        {
            listM.RemoveAt(i--);
        }
    }
    
