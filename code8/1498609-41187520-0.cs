    List<NewListType> secondListGUID = new List<NewListType>();
    foreach (var item in myfirstList)
    {
    for(int i = 0; i<_yourDBEntity.GUIDs.Count(); i++)
    {
     if(item.GUID == _yourDBEntity.GUIDs[i].GUID)
     secondListGUID.add(yournewListGUID);
    }
    }
