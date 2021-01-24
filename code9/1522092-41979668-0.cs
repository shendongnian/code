    int pos = 0, bestpos = 0, bestlen = 0;
    int len = 1;
    int[] vargu = { 2, 2, 3, 4, 5, 5, 5, 6, 9, 9, 9, 9 };
    for (int i = 0; i < vargu.Length - 1; i++)
    {
        if (vargu[i] == vargu[i+1])
        {
            len++;
            if (len > bestlen)
            {
                bestlen = len;
                bestpos = pos;
            }
        }
        else
        {
            len = 1;
            pos = i+1;
        }
    }
    for (int k = bestpos; k <= bestpos+bestlen; k++)
    {
        Console.Write("{0}", vargu[k]);
    }
    Console.ReadLine();
