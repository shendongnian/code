        public class HDataView
    {
        private SortedList mapDataRows;
        int numMapLevels;
        public HDataView(DataTable tbl, string[] colNames)
        {
            object colVal = null;
            string colName = "";
            SortedList currLvlMap = null, nextLvlMap = null;
            DataRow dr1 = null;
            ArrayList arlLastLvlData;
            mapDataRows = new SortedList();
            numMapLevels = colNames.Length;
            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                dr1 = tbl.Rows[i];
                currLvlMap = mapDataRows;
                for (int j = 0; j < colNames.Length; j++)
                {
                    colName = colNames[j];
                    colVal = dr1[colName];
                    if (j == colNames.Length - 1)
                    {
                        arlLastLvlData = (ArrayList)currLvlMap[colVal];
                        if (arlLastLvlData == null)
                        {
                            arlLastLvlData = new ArrayList();
                            currLvlMap[colVal] = arlLastLvlData;
                        }
                        arlLastLvlData.Add(dr1);
                    }
                    else
                    {
                        nextLvlMap = (SortedList)currLvlMap[colVal];
                        if (nextLvlMap == null)
                        {
                            nextLvlMap = new SortedList();
                            currLvlMap[colVal] = nextLvlMap;
                        }
                        //For the next column, the current nextLvlMap will become the prevLvlMap
                        currLvlMap = nextLvlMap;
                    }
                }
            }
        }
        public ArrayList FindAnyRows(object[] keys)
        {
            object keyVal = "";
            ArrayList arlDataRows = null, arlCurrRows = null;
            SortedList startLvlMap = null, currLvlMap = null, nextLvlMap = null;
            int mapLevel = 1, startLevel = 0;
            currLvlMap = mapDataRows;
            mapLevel = 1;
            for (int i = 0; i < keys.Length; i++)
            {
                keyVal = keys[i];
                if (currLvlMap == null)
                {
                    break;
                }
                if (i == numMapLevels - 1)
                {
                    arlDataRows = (ArrayList)currLvlMap[keyVal];
                }
                else
                {
                    nextLvlMap = (SortedList)currLvlMap[keyVal];
                    currLvlMap = nextLvlMap;
                    mapLevel++;
                }
            }
            if (arlDataRows == null)
            {
                arlDataRows = new ArrayList();
            }
            if (keys.Length > 0 && keys.Length < numMapLevels)
            {
                if (currLvlMap != null)
                {
                    startLvlMap = currLvlMap;
                    startLevel = mapLevel;
                    if (mapLevel == numMapLevels)
                    {
                        for (int j = 0; j < startLvlMap.Count; j++)
                        {
                            arlCurrRows = (ArrayList)startLvlMap.GetByIndex(j);
                            if (arlCurrRows != null)
                            {
                                arlDataRows.AddRange(arlCurrRows);
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < startLvlMap.Count; i++)
                        {
                            mapLevel = startLevel;
                            currLvlMap = startLvlMap;
                            //travel full depth of this map, for each element of this map
                            for (; mapLevel <= numMapLevels; mapLevel++)
                            {
                                if (mapLevel == numMapLevels)
                                {
                                    for (int j = 0; j < currLvlMap.Count; j++)
                                    {
                                        arlCurrRows = (ArrayList)currLvlMap.GetByIndex(j);
                                        if (arlCurrRows != null)
                                        {
                                            arlDataRows.AddRange(arlCurrRows);
                                        }
                                    }
                                }
                                else
                                {
                                    //Next level of current element of the starting map
                                    nextLvlMap = (SortedList)currLvlMap.GetByIndex(i);
                                    currLvlMap = nextLvlMap;
                                }
                            }
                        }
                    }
                }
            }
            return arlDataRows;
        }
    }
