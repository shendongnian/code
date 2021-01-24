     public class OptionComparer : IEqualityComparer<OptionDTO>
        {
            public bool Equals(OptionDTO x, OptionDTO y)
            {
                if (object.ReferenceEquals(x, y))
                {
                    return true;
                }
                if (object.ReferenceEquals(x, null) ||
                    object.ReferenceEquals(y, null))
                {
                    return false;
                }
                return x.OptionTypeID == y.OptionTypeID ;
            }
    
            public int GetHashCode(OptionDTO obj)
            {
                if (obj == null)
                {
                    return 0;
                }
                return obj.OptionTypeID.GetHashCode();
            }
