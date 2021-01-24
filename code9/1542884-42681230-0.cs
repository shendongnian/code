      public class ExcelFiltersManager
    {
        public static class ExcelFilters
        {
            public const string Equal = "equals";
            public const string GreaterThen = "greaterthan";
            // complete here the other operators.
        }
        static class Operators
        {
            // C# compiler converts overloaded operators to functions with name op_XXXX where XXXX is the opration
            public const string Equality = "op_Equality";
            public const string InEquality = "op_Inequality";
            public const string LessThan = "op_LessThan";
            public const string GreaterThan = "op_GreaterThan";
            public const string LessThanOrEqual = "op_LessThanOrEqual";
            public const string GreaterThanOrEqual = "op_GreaterThanOrEqual";
        }
        public bool GetOperatorBooleanResult<T>(string excelFilter, T value1, T value2)
        {
            MethodInfo mi = typeof(T).GetMethod(GetOperatorCompileName(excelFilter), BindingFlags.Static | BindingFlags.Public);
            return (bool)mi.Invoke(null, new object[] { value1, value2 });
        }
        private string GetOperatorCompileName(string excelFilter)
        {
            string operatorCompileName = string.Empty;
            switch (excelFilter)
            {
                case ExcelFilters.Equal:
                    operatorCompileName = Operators.Equality;
                    break;
                case ExcelFilters.GreaterThen:
                    operatorCompileName = Operators.GreaterThan;
                    break;
                    // continue here the mapping with the rest of operators
            }
            return operatorCompileName;
        }
    }
  
