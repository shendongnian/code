        public static void Set(this SerializedObject so, string name, Action<SerializedProperty> setter) {
            var property = so.FindProperty(name);
            if (property == null) {
                ;//handle "not found"
            }
            setter(property);
        }
