        public abstract TypeSafeObject<T> : TypeUnsafeObject
        { 
            public abstract T GetTypeSafeObject();
            public abstract void SetTypeSafeObject(T obj);
            public override object GetObject() {
                return GetTypeSafeObject();
            }
            public override void SetObject(object obj) {
                var typeSafeObj = obj as T;
                if (typeSafeObj != null) {
                    SetTypeSafeObj(typeSafeObj);
                }
                else {
                // report failure
                }
            }
        }
