    object GetPropertyValueWithoutReflection(object obj, string propertyName)
    {
        MethodInfo propertyGetter = obj.GetMethod("get_" + propertyName, BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
        Func<object> getPropertyValue = (Func<object>)Delegate.CreateDelegate(typeof(Func<object>), obj, propertyGetter);
        return getPropertyValue();
    }
