        public static class DynamicToStatic
        {
         public static T ToStatic<T>(object source, T destination)
         {
            var entity = destination;
    
            //source implements dictionary
            var properties = source as IDictionary<string, object>;
    
            if (properties == null)
                return entity;
    
            foreach (var entry in properties)
            {
                var propertyInfo = entity.GetType().GetProperty(entry.Key);
                if (propertyInfo != null && entry.Value != null)//Check property and its values exist or not ,change only when source contains value
                    propertyInfo.SetValue(entity, entry.Value, null);
            }
            return entity;
        }
     }
