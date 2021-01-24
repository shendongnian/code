    public class SortbyDate :IComparer<OilChange>
    {
        public int Compare(OilChange x, OilChange y)
        {
            DateTime dateX = Convert.ToDateTime(x.ServiceDate);
            DateTime dateY = Convert.ToDateTime(y.ServiceDate);
            return dateX.CompareTo(dateY);
        }
    }
