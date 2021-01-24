        public static class Extensions
        {
            public static List<List<TEntity>> ToFixedSizeGroups<TEntity>(this IEnumerable<TEntity> list1, IEnumerable<TEntity> list2, int take1, int take2)
            {
                // check if the collection is a list already
                var list1Enumerated = list1 as IList<TEntity> ?? list1.ToList();
                var list2Enumerated = list2 as IList<TEntity> ?? list2.ToList();
                // If we want to use a single for loop we need to know max-length
                var longerList = list1Enumerated.Count > list2Enumerated.Count ? list1Enumerated : list2Enumerated;
                var grouppedList1 = new List<List<TEntity>>(list1Enumerated.Count / take1);
                var grouppedList2 = new List<List<TEntity>>(list2Enumerated.Count / take2);
                // iterate the max-length list and add stuff as we go
                for (var i = 0; i < longerList.Count; i++)
                {
                    if (i < list1Enumerated.Count)
                    {
                        if (grouppedList1.Count == i / take1)
                        {
                            grouppedList1.Add(new List<TEntity>());
                        }
                        if (i < list1Enumerated.Count)
                        {
                            grouppedList1[i / take1].Add(list1Enumerated[i]);
                        }
                    }
                    if (i < list2Enumerated.Count)
                    {
                        if (grouppedList2.Count == i / take2)
                        {
                            grouppedList2.Add(new List<TEntity>());
                        }
                        grouppedList2[i / take2].Add(list2Enumerated[i]);
                    }
                }
                
                return grouppedList1.Where(x => x.Count == take1).Zip(grouppedList2.Where(x => x.Count == take2), (x, y) => x.Concat(y).ToList()).ToList();
            }
        }
