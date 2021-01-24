    private static Dictionary<string, List<object>> GetListAttributeDifferences<TFrom, TTo>(TFrom fromProperty, TTo toProperty)
            where TFrom : class
            where TTo : class
    {
        //Get types for list containing types
        Type fromPropertyListContainingType = fromProperty.GetType().GetGenericArguments()[0];
        Type toPropertyListContainingType = toProperty.GetType().GetGenericArguments()[0];
        return null;
    }
