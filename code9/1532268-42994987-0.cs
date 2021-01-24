        void Serialize(Stream stream, T value)
        {
            if (object.Equals(value, null)) { return; }
            var type = typeof(T);
            if (type == typeof(int)) { ... return ; }
            if (type == typeof(string)) { ... return; }
            var properties = type.GetProperties();
            foreach (property in properties)
            {
                var value = property.GetValue(value);
                ...
            }
        }
    }
