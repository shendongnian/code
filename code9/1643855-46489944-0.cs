    public class TempDataList<T> : List<TempData>
    {
        public TempDataList() : base()
        {
        }
        public TempDataList(IEnumerable<TempData> collection) : base(collection)
        {
        }
        public TempData GetMaxTemp(DateTime startDate, DateTime endDate)
        {
            TempData highestTempData = null;
            for (int i = 0; i < this.Count; i++)
            {
                if (this[i].Date >= startDate && this[i].Date <= endDate)
                {
                    if (highestTempData == null || this[i].Temp > highestTempData.Temp)
                    {
                        highestTempData = this[i];
                    } 
                }
            }
            return highestTempData;
        }
        public TempData GetMinTemp(DateTime startDate, DateTime endDate)
        {
            TempData lowestTempData = null;
            for (int i = 0; i < this.Count; i++)
            {
                if (this[i].Date >= startDate && this[i].Date <= endDate)
                {
                    if (lowestTempData == null || this[i].Temp < lowestTempData.Temp)
                    {
                        lowestTempData = this[i];
                    }
                }
            }
            return lowestTempData;
        }
    }
