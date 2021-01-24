    public static IEnumerable<int> ProcessAndOr(List<string> andOrList, params List<int>[] Input)
    {
    	var lst = new List<IEnumerable<int>>(Input);
    	for(int i = andOrList.Count -1  ; i >= 0 ; i--)
    		if(andOrList[i] == "AND")
    		{
    			lst[i] = lst[i].Intersect(lst[++i]);
    			lst.RemoveAt(i--);
    		}
    	return lst.SelectMany(l=>l).Distinct();
    }
