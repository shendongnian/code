    public void SetNullPropertiesToEmptyString(object root) {
        var queue = new Queue<object>();
        queue.Enqueue(root);
        while (queue.Count > 0) {
            var current = queue.Dequeue();
            foreach (var property in current.GetType().GetProperties()) {
                var propertyType = property.PropertyType;
                var value = property.GetValue(current, null);
                if (propertyType == typeof(string) && value == null) {
                    property.SetValue(current, string.Empty);
                } else if (propertyType.IsClass && value != null && !queue.Contains(value)) {
                    queue.Enqueue(value);
                }
            }
        }
    }
