    public static T TransformValues<T>(object source, T destination)
    {
        try {
            // If any this null throw an exception
            if (source == null || destination == null)
                throw new Exception("Source or/and Destination Objects are null");
            // Getting the Types of the objects
            Type typeDest = destination.GetType();
            Type typeSrc = source.GetType();
            // Iterate the Properties of the source instance and  
            // populate them from their desination counterparts  
            PropertyInfo[] srcProps = typeSrc.GetProperties();
            foreach (PropertyInfo srcProp in srcProps) {
                if (!srcProp.CanRead) {
                    continue;
                }
                PropertyInfo targetProperty = typeDest.GetProperty(srcProp.Name);
                if (targetProperty == null) {
                    continue;
                }
                if (!targetProperty.CanWrite) {
                    continue;
                }
                if (targetProperty.GetSetMethod(true) != null && targetProperty.GetSetMethod(true).IsPrivate) {
                    continue;
                }
                if ((targetProperty.GetSetMethod().Attributes & MethodAttributes.Static) != 0) {
                    continue;
                }
                if (!targetProperty.PropertyType.IsAssignableFrom(srcProp.PropertyType)) {
                    continue;
                }
                // Passed all tests, lets set the value
                targetProperty.SetValue(destination, srcProp.GetValue(source, null), null);
            }
        }
        catch (Exception ex) {
            throw new Exception(ex.ToString());
        }
        return destination;
    }
