    Dictionary<string, int> dictionaryColIndexs = new Dictionary<string, int>();
    for (int col = 0; col < maxColumns; col++)
    {
       dictionaryColIndexs.Add(valueArray[0,col],col);
    }
...
    private int MapCol(string colName)
    {
       if (dictionaryColIndexs.ContainsKey(colName))
       {
          int index= dictionaryColIndexs[colName];
          return index;
       }
       return -1;
    }
