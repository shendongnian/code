    var index1 = 0;
    foreach (var groupFile in quickHashGroup)
    {
        var index2 = 0;
        foreach (var groupFile2 in quickHashGroup)
        {                               
            if (index1 != index2 && HashTool.ByteToByteCompare(groupFile.FileName, groupFile2.FileName))
            {
                groupFile.FullHash = count.ToString();
                groupFile2.FullHash = count.ToString();
            }                                                           
            index2++;
         }
         index1++;
         count; // Why is that here? 
     }
