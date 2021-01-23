    var dict = new PageVersusRowCheckboxStatus();
    dict.SetRowStatus(2, 1, true);
    dict.SetRowStatus(2, 5, true);
    dict.SetRowStatus(3, 5, true);
    dict.SetRowStatus(4, 2, true);
    // ...
    //  Here's how to do the query that returns ( 1, 5 ) for page index key 1
    int pageIndexKey = 1;
    if (dict.ContainsKey(pageIndexKey))
    {
        foreach (int row in dict[pageIndexKey].Keys)
        {
            //  Do something
        }
    }
    // ...
    public class RowStatusDictionary : Dictionary<int, Dictionary<int, bool>>
    {
        public void SetRowStatus(int pageIndex, int row, bool status)
        {
            Dictionary<int, bool> rowStatuses = null;
            int pageIndexKey = pageIndex - 1;
            if (!this.TryGetValue(pageIndexKey, out rowStatuses))
            {
                this[pageIndexKey] = new Dictionary<int, bool>();
            }
            rowStatuses[row] = status;
        }
        public bool GetRowStatus(int pageIndex, int row)
        {
            Dictionary<int, bool> rowStatuses = null;
            int pageIndexKey = pageIndex - 1;
            if (TryGetValue(pageIndexKey, out rowStatuses))
            {
                return rowStatuses[row];
            }
            return false;
        }
    }
