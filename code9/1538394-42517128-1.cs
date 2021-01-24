    private bool CheckAllProperties(UserGroup instance)
    {
         return instance.GetType().GetProperties()
                        .Where(c => c.GetValue(instance) is string)
                        .Select(c => (string)c.GetValue(instance))
                        .All(c => c== "random");
    }
