    public class DateTimeOffsetHelper
    {
        public static DateTimeOffset FromString(string offsetString)
        {
            DateTimeOffset offset;
            if (DateTimeOffset.TryParse(offsetString, out offset))
            {
                offset = DateTimeOffset.Now;
            }
            return offset;
        }
    }
