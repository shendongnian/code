    public static string ReplaceFirstOccurence(string originalValue, string occurenceValue, string newValue)
        {
            if (string.IsNullOrEmpty(originalValue))
                return string.Empty;
            if (string.IsNullOrEmpty(occurenceValue))
                return originalValue;
            if (string.IsNullOrEmpty(newValue))
                return originalValue;
            int startindex = originalValue.IndexOf(occurenceValue);
            return originalValue.Remove(startindex, occurenceValue.Length).Insert(startindex, newValue);
        }
 
        public static string ReplaceLastOccurence(string originalValue, string occurenceValue, string newValue)
        {
            if (string.IsNullOrEmpty(originalValue))
                return string.Empty;
            if (string.IsNullOrEmpty(occurenceValue))
                return originalValue;
            if (string.IsNullOrEmpty(newValue))
                return originalValue;
            int startindex = originalValue.LastIndexOf(occurenceValue);
            return originalValue.Remove(startindex, occurenceValue.Length).Insert(startindex, newValue);
        }
