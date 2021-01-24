    IEnumerable<int> activeIds = secondList.Select(item => item.Id);
    foreach (Doc doc in firstList)
    {
        doc.IsActive = activeIds.Contains(doc.Id);
    }
