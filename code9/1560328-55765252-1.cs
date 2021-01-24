    public static class ExpressionHelper
    {
        //https://stackoverflow.com/questions/18313362/call-function-in-dynamic-linq
        private static bool _utilsAdded = false;
        private static void AddUtilites()
        {
            if (_utilsAdded == true)
                return;
            _utilsAdded = true;
            var type = typeof(DynamicQueryable).Assembly.GetType("System.Linq.Dynamic.ExpressionParser");
            FieldInfo field = type.GetField("predefinedTypes", BindingFlags.Static | BindingFlags.NonPublic);
            Type[] predefinedTypes = (Type[])field.GetValue(null);
            Array.Resize(ref predefinedTypes, predefinedTypes.Length + 1);
            predefinedTypes[predefinedTypes.Length - 1] = typeof(Int32List); // Your type
            field.SetValue(null, predefinedTypes);
        }
    }
