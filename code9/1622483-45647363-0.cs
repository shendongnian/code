    for (int s = 0; s < draw; s++)
            {
                for (int i = 0; i < 5; i++)
                {
                    x = ranNumber.Next(minValue, maxValue);
                    storeNumArray[i] = x;
                    if (i == 4)
                    {
                        list = new List<int[]>();
                        list.Add(storeNumArray);
                    }
                }
                while (y < 5)
                {
                    Mega = ranNumber.Next(maxValue);
                    temp = storeNumArray[y];
                    if (Mega != temp)
                    {
                        y = 5;
                        break;
                    }
                }
                foreach (int[] g in list)
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (int num in g)
                    {
                        sb.Append(' ' + num.ToString());
                    }
                    Console.WriteLine(sb.ToString());
                }
            }
