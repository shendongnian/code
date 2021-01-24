    public static class SQLFunctions
    {
       [Function(FunctionType.BuiltInFunction, "DATE_TO_STRING")]
       public static string SqlDateToString(this DateTime value) => Function.CallNotSupported<string>();
    }
