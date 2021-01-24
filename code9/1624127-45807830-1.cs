    [ChildActionOnly]
    public ActionResult RenderChecklist(IGrouping<string, ChecklistItem> list,
            int checklistCount, int checklistCounter, int priorityCounter)
    {
        var parentFolder = list.First().UmbracoContent.Parent;
        var listCount = list.Count();
        var itemData = new ValueTuple<int, int, string>(1, 1, null);
        var color = GetChecklistColorValue(parentFolder);
    
        itemData = list.OrderBy(x => x.IsChecked).ThenBy(x => x.SortOrder).Aggregate(itemData,
            (current, item) => GetItemList(item, current.Item1, current.Item2, current.Item3, listCount));
    
        var itemCounter = itemData.Item1;
        var itemCheckedCounter = itemData.Item2;
        var itemList = itemData.Item3;
    
        var checklistDict = GetChecklistRestrictions(parentFolder, itemCounter,
            itemCheckedCounter, priorityCounter);
    
        checklistDict.Add("color", color);
        checklistDict.Add("itemList", itemList);
        checklistDict.Add("checklistCounter", checklistCounter);
    
        return GetChecklistLayout(checklistCount, checklistLayoutDict);
    }
