    public Map GetMap(List<Map> map, string name, string finalName = null) {
        var item = map.SingleOrDefault(m => m.Name == name);
    	
        if (item != null && name != item.Class) {
            return GetMap(map, item.Class, finalName ?? name); // <- for you, name ?? @class
        } else {
            return new Map(finalName ?? name, name);
        }
    }
