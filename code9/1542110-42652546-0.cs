    for (int i = 0; i < region1.Count && i < region2.Count; i++)
    {
        for (int a = 0; a < region1[i].ParentName.Length && a < region2[i].ParentName.Length; a++)
        {
            var strs = region1[i].ParentName[a].Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            var str2 = region2[i].ParentName[a].Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
    
            region1[i].ParentName[a] = String.Join(",", str2.Concat(str2).Distinct());
        }
    }
