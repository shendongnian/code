    private static Map GetMap(List<Map> map, string name) {
    	var down = GetMapDown(map, name);
    	var upItem = GetMapUp(map, name);
    	return new Map(upItem.Name, down.Class);
    }
    
    private static Map GetMapDown(List<Map> map, string name, string finalName = null) {
        var item = map.SingleOrDefault(m => m.Name == name);
    	
        if (item != null && name != item.Class) {
            return GetMapDown(map, item.Class, finalName ?? name);
        } else {
            return new Map(finalName ?? name, name);
        }
    }
    
    private static Map GetMapUp(List<Map> map, string name, string finalName = null) {
        var item = map.SingleOrDefault(m => m.Class == name);
    	
        if (item != null && name != item.Name) {
            return GetMapUp(map, item.Name, name);
        } else {
            return new Map(name, finalName ?? name);
        }
    }
