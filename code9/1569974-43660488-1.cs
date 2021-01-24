    class MetaObject
    {
        string meta_key { get; set; }
        string meta_value { get; set; }
    }
    class Settings
    {
        IEnumerable<MetaObject> MetaObjects { get; set; }
        string GetValueOfProp(string PropName){
            ...
        }
    }
