    static void FilterList<T>(List<T> masterList, ObservableCollection<T> filteredList, Func<T, bool> filterExpression)
    {
        foreach (var item in masterList)
        {
            if (filterExpression(item))
            {
                if (!filteredList.Contains(item))
                {
                    filteredList.Add(item);
                }
            }
            else
            {
                if (filteredList.Contains(item))
                {
                    filteredList.Remove(item);
                }
            }
        }
    }
