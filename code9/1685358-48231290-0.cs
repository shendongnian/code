    public class CustomType {
        public int myField;
        
        private int myProperty;
        public int MyProperty {
            get { return myProperty; }
            set {
                if (value != myProperty) {
                    // do stuff here
                    myProperty = value;
                }
            }
        }
        public void OnMyFieldChanged(int from, int to) {
            // do stuff here
        }
    }
    #if UNITY_EDITOR
        [CustomEditor(typeof(CustomType))]
        class CustomTypeEditor : Editor {
            public override void OnInspectorGUI() {
                CustomType customType = (CustomType)target;
                int field = EditorGUILayout.IntField("Field", customType.myField);
                if (field != customType.myField) {
                    customType.OnMyFieldChanged(customType.myField, field);
                    customType.myField = field;
                }
                customType.MyProperty = EditorGUILayout.IntField("Property", customType.MyProperty);
            }
        }
    #endif
