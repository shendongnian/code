    interface IKeyedObject {
        string Key { get; };
    }
    
    class BaseWithKey : IKeyedObject {
        public string Key { get; };
    }
    
    class DerivedA : BaseWithKey {
    }
    
    class DerivedB : BaseWithKey {
    }
    
    class OtherWithKey : IKeyedObject {
        public string Key { get; };
    }
    
    //Solution with base class (will work with BaseWithKey, DerivedA, DerivedB)
    
    T GetItemBaseClass(List<T> list, string key)
        where T : BaseWithKey {
    
        return list.FirstOrDefault(u=>u.Key == key);
    }
    
    //Solution with interface (will work with all classes)
    
    T GetItemInterface(List<T> list, string key)
        where T : IKeyedObject {
    
        return list.FirstOrDefault(u=>u.Key == key);
    }
