    var dict = new PageVersusRowCheckboxStatus();
    dict.SetRowStatus(j, PageIndex, true);
    //....
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
