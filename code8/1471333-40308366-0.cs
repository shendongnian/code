     static char[][] SortSimiliarity(char[][] arr, char[] key, int arrRow)
                {
                // init dict
    
                Dictionary<char, int> dict = new Dictionary<char, int>();
    
                // init new matrix
                char[][] tempArray = new char[5][];
                for(var i = 0; i < 5; i++)
                {
                    tempArray[i] = new char[5];
                }
    
                // copy new sorted keys
                for (var i = 0; i < key.Length; i++)
                {
                    for (var j = 0; j < key.Length; j++)
                    {
                        if (key[i] == arr[arrRow][j])
                        {
                            if (!dict.ContainsKey(key[i]))
                            {
                                dict.Add(key[i], j);
                                for(var k = 0; k < key.Length; k++)
                                {
                                    tempArray[k][i] = arr[k][j];
                                }
                                break;
                            }
                            else
                            {
                                if(j != dict[key[i]])
                                {
                                    for (var k = 0; k < key.Length; k++)
                                    {
                                        tempArray[k][i] = arr[k][j];
                                    }
                                    dict[key[i]] = j+1;
                                }
                            }
                        }
                    }
                }
                return tempArray;
            }
