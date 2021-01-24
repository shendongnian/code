    public class SortbyDate :IComparer<OilChange>
    {
        public int Compare(OilChange x, OilChange y)
        {
            DateTime dateX = Convert.ToDateTime(x);
            DateTime dateY = Convert.ToDateTime(y);
            return dateX.CompareTo(dateY);
        }
    }
