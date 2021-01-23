    static void SomeMethod(IEnumerable<File> inputFiles)
    {
        var groupedItems = inputFiles.GroupBy(
            q => CanSplitAndFindElement(q.Name, '_', 2) ? q.Name.ToLower().Split('_').ElementAt(2)
                                                        : string.Empty);
        string currentNo = //whatever;
        if (string.IsNullOrEmpty(currentNo))
        {
            if (groupedItems.Count() > 1)
            {
                foreach (var item in groupedItems.SelectMany(g => g))
                {
                    ErrorFile(item);
                }
            }
            else if (groupedItems.Count() == 1)
            {
                ProcessFile();
            }
        }
        else
        {
            foreach (var item in groupedItems.Where(g => g.Key != currentNo).SelectMany(g => g))
            {
                ErrorFile(item);
            }
        }
    }
