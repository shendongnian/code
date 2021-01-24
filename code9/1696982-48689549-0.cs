    public static T Get<T>(this SerializedObject so, string name) {
        if (typeof(T) == typeof(bool){
            return (T)(object)so.FindProperty(name).boolValue;
        }
        else if {
        ...
        }
        else {
            Debug.LogError("Get called with unsuported type!");
        }
    }
