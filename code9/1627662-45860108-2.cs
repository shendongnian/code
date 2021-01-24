    List<Int32?> list1 =new List<int?>() { 1, null, 2 };
                    List<Int32> list2 = new List<int>();
                    foreach (var item in list1)
                    {
                        if (item.HasValue)
                            list2.Add(item.Value);
                    }
