    var indexMap = new Dictionary<int, int>();
    int nextIndex = 0;
    var RestructuredList = new List<int>(SubFaceList.Count); // final capacity
    foreach (var item in SubFaceList)
    {
    	int index;
    	if (!indexMap.TryGetValue(item, out index))
    		indexMap.Add(item, index = nextIndex++);
    	RestructuredList.Add(index);
    }
