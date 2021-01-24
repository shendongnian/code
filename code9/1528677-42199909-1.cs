    public bool IsJobMethod(MethodInfo method)
    {
        if (method.ContainsGenericParameters)
        {
            return false;
        }
        if (method.GetCustomAttributesData().Any(HasJobAttribute))
        {
            return true;
        }
        if (method.GetParameters().Length == 0)
        {
            return false;
        }
        if (method.GetParameters().Any(p => p.GetCustomAttributesData().Any(HasJobAttribute)))
        {
            return true;
        }
        return false;
    }
