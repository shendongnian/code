        public static T Get<T>(this SerializedObject so, string name, Func<SerializedProperty, T> getter) {
            var property = so.FindProperty(name);
            if (property == null) {
                ;//handle "not found"
            }
            return getter(property);
        }
