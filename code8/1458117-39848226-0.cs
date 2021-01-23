            string[] itemsArr = items.ToArray();
            int countA = 0;
            foreach (string itemArr in itemsArr)
            {
                List<int> groupDuplicates = new List<int>();
                for (int a = countA; a < itemsArr.Count(); a++)
                {
                    if (itemArr != itemsArr[a])
                    {
                        if (itemArr.Split(';')[columnIndex] == itemsArr[a].Split(';')[columnIndex]) //if matched then add
                        {
                            groupDuplicates.Add(a); // listing index to be remove
                        }
                        else
                            break; //no way to go through the bottom of the list and also to make the performance faster
                    }
                    countA++;
                }
                if (groupDuplicates.Count() != 0)
                {
                    groupDuplicates.Add(groupDuplicates.First() - 1); //I add here the first item in duplicates
                    foreach (int m in groupDuplicates)
                    {
                        _items.Remove(items.ElementAt(m)); //remove by item not by index
                    }
                }
            }
