    List<int> list1 = new List<int>();
    
                list1.Add(1);
                list1.Add(2);
    
                // Now this is your refresh which will load all data from first load, plus the refresh load
                List<int> list2 = new List<int>();
                list2 = list1;
                list2.Add(3);
                list2.Add(4);
                list2.Add(5);
    
                // Now you want the new values only in list2
                // Like we said, keep the original list1 in local variable so you can do this
                foreach (var l in list1)
                {
                    if (list2.Contains(l))
                        list2.Remove(l);
                }
