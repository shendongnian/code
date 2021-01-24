        private static bool CheckPropertiesAsNullRecursively(object obj)
        {
            if (obj == null)
            {
                return true;
            }
            var objType = obj.GetType();
            if (objType.IsPrimitive || objType == typeof(Decimal) || objType == typeof(String) || objType == typeof(Double))//You should compare the primitive types to determine them
            {
                return false;
            }
            var properties = objType.GetProperties();
            foreach (var propertyInfo in properties)
            {
                if (CheckPropertiesAsNullRecursively(objType.GetProperty(propertyInfo.Name).GetValue(obj)))
                {
                    return true;
                }
            }
            return false;
        }
