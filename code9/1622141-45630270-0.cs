    class Example
    {
        private SomeClass ObjA;
        private SomeClass ObjB;
        void CallObjectMethod(string suffix)
        {
            string name = "Obj" + suffix;
            var fieldInfo = this.GetType().GetField(name, BindingFlags.Instance | BindingFlags.NonPublic);
            if (fieldInfo == null || (fieldInfo.FieldType != typeof(SomeClass)) throw ArgumentException(nameof(suffix));
            SomeClass obj = fieldInfo.GetValue(this);
            obj.CommonMethod();
        }
    }
        
