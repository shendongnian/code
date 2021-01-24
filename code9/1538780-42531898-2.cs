      bool matchFound = false; // an indicator if match is found in table 2
            foreach (var item in data1)
            {
                foreach (var item2 in data2)
                {
                    if (item.CarReg != item2.CarReg)
                    {
                        matchFound = false;
                    }
                    else
                    {
                        matchFound = true;
                        break;
                    }
                }
                if (!matchFound)
                {
                    if (!oneList.Contains(item))
                    {
                        oneList.Add(item);
                    }
                }
            }
