    public class AlphanumComparator : IComparer<string>
    {
        public int Compare(string str1, string str2)
        {
            if (IsNumeric(str1) && IsNumeric(str2))
            {
                if (Convert.ToInt32(str1) > Convert.ToInt32(str2)) return 1;
                if (Convert.ToInt32(str1) < Convert.ToInt32(str2)) return -1;
                if (Convert.ToInt32(str1) == Convert.ToInt32(str2)) return 0;
            }
            if (IsNumeric(str1) && !IsNumeric(str2))
                return -1;
            if (!IsNumeric(str1) && IsNumeric(str2))
                return 1;
            return String.Compare(str1, str2, StringComparison.OrdinalIgnoreCase);
        }
        public static bool IsNumeric(object value)
        {
            try
            {
                int num = Convert.ToInt32(value.ToString());
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
