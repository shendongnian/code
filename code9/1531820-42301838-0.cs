    public Map GetMap(List<Map> map, string name, string finalName = null) {
        var item = map.FirstOrDefault(m => m.Name == name); // I also changed this
    	
        if (item != null && name != item.Class) {
            return GetMap(map, item.Class, finalName ?? name); // <- for you, name ?? @class
        } else {
            return new Map(finalName ?? name, name);
        }
    }
