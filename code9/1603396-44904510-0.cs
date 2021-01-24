    var paramList = params.Where(x => x.PathType.Equals("path") || x.PathType.Equals("query"));
    var groupedParams  = paramList.GroupBy(a => a.Name, StringComparer.InvariantCultureIgnoreCase).ToDictionary(t => t.Key);
    foreach (var item in groupedParams) {
    	var temp = item.Value.Count() > 1;
    	if (temp) {
    		var paramToDelete = operation.parameters.FirstOrDefault(x => x.Name.ToLower() == item.Key.ToLower() && x.PathType == "query");
    		if (paramToDelete != null) {
    			operation.parameters.Remove(paramToDelete);
    		}
    	}
    }
