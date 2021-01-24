    public static class StringExtension
    {
        public static bool ContainsInOrder(this string value, params string[] args)
        {
            if (string.IsNullOrEmpty(value) || args == null || args.Length == 0)
                return false;
            int previousIndex = -1;
            foreach (string arg in args)
            {
                if (arg == null) return false;
                int index = value.IndexOf(arg);
                if (index == -1 || index < previousIndex)
                {
                    return false;
                }
                previousIndex = index;
            }
            return true;
        }
    } 
