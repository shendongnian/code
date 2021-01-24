    var indexMap = new Dictionary<int, int>();
    var RestructuredList = new List<int>(SubFaceList.Count); // final capacity
    foreach (var item in SubFaceList)
    {
    	int index;
    	if (!indexMap.TryGetValue(item, out index))
    		indexMap.Add(item, index = indexMap.Count);
    	RestructuredList.Add(index);
    }
