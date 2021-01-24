    void Main()
    {
    	var map = new List<Map>() {
    		{ new Map("FooExtended", "FooExtended2") },
    	    { new Map("Foo", "FooExtended") },
    	    { new Map("foo", "Foo") }
    	};
    	
    	var newMap = GetMap(map, "foo");
    	newMap.Dump(); // Gives Map("foo", "FooExtended2")
    }
    
    public class Map {
        public string Name { get; set; }
        public string Class { get; set; }
    
        public Map(string name, string @class) {
            Name = name;
            Class = @class;
        }
    }
    
    private static Map GetMap(List<Map> map, string name, string finalName = null) {
        var item = map.SingleOrDefault(m => m.Name == name);
    	
        if (item != null && name != item.Class) {
            return GetMap(map, item.Class, finalName ?? name);
        } else {
            return new Map(finalName ?? name, name);
        }
    }
