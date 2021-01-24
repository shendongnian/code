    public static void SetChecklistPriorityLevel(MyAppRenderModel pageModel)
    {
        var checklist = GetCheckList(pageModel);
        var priorityCounter = 1;
    
        foreach (var list in checklist)
        {
            var listCount = list.Count();
            var itemData = new ValueTuple<int, int, string>(1, 1, null);
    
            itemData = list.OrderBy(x => x.IsChecked).ThenBy(x => x.SortOrder).Aggregate(itemData,
                (current, item) => GetItemList(item, current.Item1, current.Item2, current.Item3, listCount));
    
            var itemCounter = itemData.Item1;
            var itemCheckedCounter = itemData.Item2;
            //  var itemList = itemData.Item3;
    
            priorityCounter = GetPriorityLevel(itemCounter, itemCheckedCounter, priorityCounter);
    
            pageModel.ChecklistPriorityLevel = priorityCounter;
        }
    }
