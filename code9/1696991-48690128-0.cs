    public static class MyExtensions
    {
        private static class GetPropertyValue<T>
        {
            static GetPropertyValue() => InitGetPropertyValue.Initialize();
            public static Func<SerializedObject, string, T> Get = (so, name) =>
             {
                 Debug.Print("Get called with unsupported type!");
                 return default(T);
             };
        }
        private static class InitGetPropertyValue
        {
            static InitGetPropertyValue()
            {
                Debug.Print("Initializing property getters");
                GetPropertyValue<int>.Get = (so, name) => (int)so.FindProperty(name) ;
                GetPropertyValue<Guid>.Get = (so, name) => (Guid)so.FindProperty(name);
                GetPropertyValue<string>.Get = (so, name) => so.FindProperty(name).ToString();
            }
            public static bool Initialize() => true;
        }
        public static T Get<T>(this SerializedObject so, string name)
        {
            return GetPropertyValue<T>.Get(so, name);
        }
    }
