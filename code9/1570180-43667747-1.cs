    public static class SynxHelper
    {
        public static Dictionary<string, string> Serialize<T>(T obj)
        {
            return typeof(T).GetProperties()
                .Select(x => new
                {
                    SyncProperty = x.GetCustomAttribute<SyncProperty>(),
                    Value = x.GetValue(obj)
                })
                .Where(x => x.SyncProperty != null)
                .ToDictionary(x => x.SyncProperty.PropertyName, x => x.Value.ToString());
        }
    }
    
    // usage
    var collection = SynxHelper.Serialize(contact);
