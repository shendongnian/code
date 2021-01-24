    public class CodeComparer : IComparer<MyEntity>
    {
        public int Compare(MyEntity x, MyEntity y)
        {
            if (x == null)
            {
                if (y == null)
                {
                    // If x is null and y is null, they're
                    // equal. 
                    return 0;
                }
                else
                {
                    // If x is null and y is not null, y
                    // is greater. 
                    return -1;
                }
            }
            else
            {
                // If x is not null...
                //
                if (y == null)
                    // ...and y is null, x is greater.
                {
                    return 1;
                }
                else
                {
                    return ToComparableString(x.Code).CompareTo(ToComparableString(y.Code));
                }
            }
        }
        private string ToComparableString(string input)
        {
		    var split = input.Split(new [] {'.'});
		    return string.Join(".", split.Select(x => x.PadLeft(5, '0')));
        }
    }
