    public static class CompareService
    {
        public static T CompareData<T>(this List<T> list, T itemToFind, Func<T, int> propSelector)
        {
            int propToFind = propSelector(itemToFind); // cache
            return database_list.FirstOrDefault(x => propSelector(x) == propToFind);
        } 
    }
