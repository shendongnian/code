    public class DateTimeOffsetHelper
    {
        const string ZeroOffsetString = "0000-00-00";
        public static DateTimeOffset FromString(string offsetString)
        {
            DateTimeOffset offset;
            if (offsetString == ZeroOffsetString)
            {
                offset = DateTimeOffset.Now;
            }
            else
            {
                offset = DateTimeOffset.Parse(ZeroOffsetString);
            }
            return offset;
        }
    }
