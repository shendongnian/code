        List<SecondListGUID> secondListGUID = new List<SecondListGUID>();
        foreach (var item in myfirstList)
        {
        for(int i = 0; i<_yourDBEntity.GUIDs.Count(); i++)
        {
         if(item.LpGuid == _yourDBEntity.GUIDs[i].GUID)
         secondListGUID.add(new SecondListGUID() {// add the corresponding GUID's here });
        }
        }
    
 
