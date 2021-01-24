    public static T CopyObject<T>(this T obj) where T : new()
            {
                var type = obj.GetType();
                var props = type.GetProperties();
                var fields = type.GetFields();
                var copyObj = new T();
                foreach (var item in props)
                {
                    item.SetValue(copyObj, item.GetValue(obj));
                }
                foreach (var item in fields)
                {
                    item.SetValue(copyObj, item.GetValue(obj));
                }
                return copyObj;
            }
