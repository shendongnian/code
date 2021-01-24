    List<int> ids = new List<int>() { 1, 2, 3, 5, 7, 8, 11, 13, 14 };
                    int i = 0;
                    bool isrange;
        
                    for(i=0;i<ids.Count;i++)
                    {
                        isrange = false;
                        Console.Write(ids[i]);
        
                        while (i < ids.Count-1 && ids[i + 1] == ids[i] + 1)
                        {
                            i++;
                            isrange = true;
                        }
        
                        if (isrange)
                            Console.Write("-" + ids[i]);
        
                        if (!(i + 1 == ids.Count))
                            Console.Write(",");
                    }
