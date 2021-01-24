     class Program
        {
            static void Main(string[] args)
            {
                var defaultStruct = default(MyStruct);
                PrintIsDefault(IsDefault(defaultStruct), nameof(defaultStruct));
    
                var defaultInitializedStruct = new MyStruct();
                PrintIsDefault(IsDefault(defaultInitializedStruct), nameof(defaultInitializedStruct));
    
                var nonDefaultStruct = new MyStruct { Field1 = 13 };
                PrintIsDefault(IsDefault(nonDefaultStruct), nameof(nonDefaultStruct));
    
                var defaultChar = default(char);
                PrintIsDefault(IsDefault(defaultChar), nameof(defaultChar));
    
                var nonDefaultChar = 'a';
                PrintIsDefault(IsDefault(nonDefaultChar), nameof(nonDefaultChar));
    
                var defaultObject = default(object);
                PrintIsDefault(IsDefault(defaultObject), nameof(defaultObject));
    
                var nonDefaultObject = "string";
                PrintIsDefault(IsDefault(nonDefaultObject), nameof(nonDefaultObject));
    
                var defaultClass = default(MyClass);
                PrintIsDefault(IsDefault(defaultClass), nameof(defaultClass));
    
                var defaultInitializedClass = default(MyClass);
                PrintIsDefault(IsDefault(defaultInitializedClass), nameof(defaultInitializedClass));
    
                var nonDefaultClass = new MyClass { Field1 = 1, Prop1 = 2 };
                PrintIsDefault(IsDefault(nonDefaultClass), nameof(nonDefaultClass));
    
                Console.ReadLine();
            }
    
            private static bool IsDefault<T>(T value)
            {
                var typeInfo = typeof(T).GetTypeInfo();
    
                if (typeInfo.IsClass)
                {
                    if (typeInfo.IsPrimitive || value is string || value is object)
                    {
                        return Equals(value, default(T));
                    }
                    else
                    {
                        return Equals(value, default(T)) ? true : AreMembersDefault(value);
                    }
                }
                else
                {
                    return typeInfo.IsPrimitive ? Equals(value, default(T)) : AreMembersDefault(value);
                }
            }
    
            private static bool AreMembersDefault<T>(T value)
            {
                var fields = value.GetType().GetFields();
                foreach (var field in fields)
                {
                    if (!IsDefault((dynamic)(field.GetValue(value))))
                    {
                        return false;
                    }
                }
    
                var properties = value.GetType().GetProperties();
                foreach (var prop in properties)
                {
                    if (!IsDefault((dynamic)(prop.GetValue(value))))
                    {
                        return false;
                    }
                }
    
                return true;
            }
    
            private static void PrintIsDefault(bool isDefault, string varName)
            {
                Console.WriteLine($"{varName} is default: {isDefault}");
            }
        }
