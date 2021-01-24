    public static void SortLinkedList(DataList items) 
    {
        list<object> actualList = new list<object>();
        
        for (DataList.Node j = i.Next(); j != null; j=j.Next())
        {
            list.add(j.Value());
        }
        actualList.Sort();
        
        items.Clear();
        for (int i = 0; i < actualList.Count;i++)
        {
            items.Add(actualList[i]);
        }
    }
