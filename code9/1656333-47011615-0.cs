    for (i = 0; i < lineList.Count; i++)
    {
        maxElementSize[i] = 0;
    }
    for (i = 0; i < lineList.Count; i++)
    {
        for (j = 0; j < maxColumn; j++)
        {
            if(lineList[i][j].Length > maxElementSize[j])
               maxElementSize[j] = lineList[i][j].Length
        }
    }
