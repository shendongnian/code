    public SortedDictionary<Guid, Color> GetSeriesColors(IList<Tuple<Guid, double>> heightsAboveGroundByGuid)
    {
        IEnumerable<IGrouping<double, Tuple<Guid, double>>> groupedOrderedList = heightsAboveGroundByGuid.OrderBy(h => h.Item2).GroupBy(o => o.Item2);
        int numberOfGroups = groupedOrderedList.Count();
        SortedDictionary<Guid, Color> seriesColorsByGuid = new SortedDictionary<Guid, Color>();
        int index = 0;
            
        //calculate the size of the gaps.
        float gap = (this.colors.Count() - 1) / (float)(numberofGroups - 1);
        //keep track of how many multiples of gap we need
        int gapsUsed = 1;
        foreach (IGrouping<double, Tuple<Guid, double>> item in groupedOrderedList)
        {
            if (index <= this.colors.Count() - 1)
            {
                foreach (Tuple<Guid, double> childItem in item)
                {
                    seriesColorsByGuid.Add(childItem.Item1, this.colors[index]);
                }
            }
            //set the index to the gap * gapsUsed and cast it to an int
            index = (int)(gap * gapsUsed);
            //increment gaps used
            gapsUsed++;
        }
        return seriesColorsByGuid;
    }
