    interface IKeyedObject {
        string Key { get; };
    }
    
    class BaseWithKey : IKeyedObject {
        public string Key { get; set; };
    }
    
    class DerivedA : BaseWithKey {
    }
    
    class DerivedB : BaseWithKey {
    }
    
    class OtherWithKey : IKeyedObject {
        public string Key { get; set; };
    }
    
    //Solution with base class (will work with BaseWithKey, DerivedA, DerivedB)
    
    T GetItemBaseClass<T>(List<T> list, string key)
        where T : BaseWithKey {
    
        return list.FirstOrDefault(u=>u.Key == key);
    }
    
    //Solution with interface (will work with all classes)
    
    T GetItemInterface<T>(List<T> list, string key)
        where T : IKeyedObject {
    
        return list.FirstOrDefault(u=>u.Key == key);
    }
