    var quickHashGroupList = quickHashGroup.ToList();
    for(var i = 0; i < quickHashGroupList.Count-1; i++)
    {
        var groupFile = quickHashGroupList[i];
        for(var j = i+1; j < quickHashGroupList.Count; j++)
        {
            var groupFile2 = quickHashGroupList[j];
            if (HashTool.ByteToByteCompare(groupFile.FileName, groupFile2.FileName))
            {
                groupFile.FullHash = count.ToString();
                groupFile2.FullHash = count.ToString();
            }     
        }
    }
