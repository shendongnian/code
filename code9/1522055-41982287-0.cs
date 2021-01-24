    IEnumerable<int> activeIds = secondList.Select(item => item.Id);
    IEnumerable<Doc> activeDocs = firstList.Where(item => activedIds.Contains(item.Id));
    
    foreach (Doc activeDoc in activeDocs)
    {
        activeDoc.IsActive = true;
    }
