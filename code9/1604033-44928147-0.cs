    public class RowComparer : IComparer<IEnumerable<int>>
    {
        public int Compare(IEnumerable<int> x, IEnumerable<int> y)
        {
            // TODO: throw ArgumentNullException 
            return x.Zip(y, (xItem, yItem) => xItem.CompareTo(yItem))
                    .Where(c => c != 0).FirstOrDefault();
        }
    }
