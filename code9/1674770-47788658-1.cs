    public static IEnumerable<DataNode> TimeFilter(this IEnumerable<DataNode> list, int timeDifference )
        {
            DataNode LastFound = null;
            foreach (var item in list.OrderByDescending(p=> p.Timings))
            {
                if (item.Timings > LastFound?.Timings.Add(new TimeSpan(0,0,timeDifference)))
                {
                    LastFound = item;
                    yield return item;
                }
            }
        }
