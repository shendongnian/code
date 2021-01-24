        private void InitializeAllCollections()
        {
            var properties = this.GetType().GetProperties();
            foreach (var property in properties)
            {
                var genericType = property.PropertyType.GetGenericArguments();
                var creatingCollectionType = typeof(List<>).MakeGenericType(genericType);
                property.SetValue(this, Activator.CreateInstance(creatingCollectionType));
            }
        }
