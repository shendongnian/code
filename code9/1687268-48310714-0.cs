    public class ItemGroupConverter : IValueConverter, IComparer
    {
        //... your existing implementation of Convert and ConvertBack
		public int Compare(object x, object y)
		{
			return ((IComparable)Convert(x, null, null, null)).CompareTo(((IComparable)Convert(y, null, null, null)));
		}
    }
