    int max = Math.Max(infoList.Count,linkList.Count);
        for (int i = 0; i < max; i++)
        {
            if (i < infoList.Count)
                Console.Write(infoList.ElementAt(i) + "  ");
            if (i < linkList.Count)
                Console.Write(linkList.ElementAt(i) + "  ");
        }
