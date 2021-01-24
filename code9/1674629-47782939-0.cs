    public static class Extentions
    {
        public static List<T> Filter<T>(this List<T> list, List<T> filterList)
        {
            return list.Where(v => !filterList.Contains(v)).Select(r => r).ToList();
        }
    }
