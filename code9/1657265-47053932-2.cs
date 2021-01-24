        public static class Extensions
        {
            public static List<List<TEntity>> ToFixedSizeGroups<TEntity>(this IEnumerable<TEntity> list1, IEnumerable<TEntity> list2, int take1, int take2)
            {
                // check if the collection is a list already
                var list1Enumerated = list1 as IList<TEntity> ?? list1.ToList();
                var list2Enumerated = list2 as IList<TEntity> ?? list2.ToList();
                // If we want to use a single for loop we need to know max-length
                var longerList = list1Enumerated.Count > list2Enumerated.Count ? list1Enumerated : list2Enumerated;
                var grouppedList1 = Enumerable.Range(0, list1Enumerated.Count / take1).Select(x => new List<TEntity>()).ToList();
                var grouppedList2 = Enumerable.Range(0, list2Enumerated.Count / take2).Select(x => new List<TEntity>()).ToList();
                for (var i = 0; i < longerList.Count; i++)
                {
                    if (i < list1Enumerated.Count && i / take1 < grouppedList1.Count)
                    {
                        grouppedList1[i / take1].Add(list1Enumerated[i]);
                    }
                    if (i < list2Enumerated.Count && i / take2 < grouppedList2.Count)
                    {
                        grouppedList2[i / take2].Add(list2Enumerated[i]);
                    }
                }
                
                return grouppedList1.Where(x => x.Count == take1).Zip(grouppedList2.Where(x => x.Count == take2), (x, y) => x.Concat(y).ToList()).ToList();
            }
        }
