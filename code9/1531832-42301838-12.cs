    private static Map GetMap(List<Map> map, string name) {
    	return new Map(GetMapName(map, name), GetMapClass(map, name));
    }
    
    private static string GetMapName(List<Map> map, string name) {
        var item = map.SingleOrDefault(m => m.Name != name && m.Class == name);
        return item != null ? GetMapName(map, item.Name) : name;
    }
    private static string GetMapClass(List<Map> map, string name) {
        var item = map.SingleOrDefault(m => m.Name == name && m.Class != name);
        return item != null ? GetMapClass(map, item.Class) : name;
    }
