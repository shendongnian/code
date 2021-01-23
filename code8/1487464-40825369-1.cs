    class Program
    {
        static Dictionary<Type, int> TypeDefs = new Dictionary<Type, int>()
        {
            {typeof(Int16), 1},
            {typeof(Int32), 2},
            {typeof(Int64), 3},
            {typeof(IntPtr), 4},
            {typeof(char), 5},
            {typeof(String), 6}
        };
        static KeyValuePair<Type,object>[] _Types = new[] 
            { new KeyValuePair<Type,object> ( typeof(Int16),5 ),
            new KeyValuePair<Type,object> (typeof(Int32),57 ),
            new KeyValuePair<Type,object> (typeof(Int64),157 ),
            new KeyValuePair<Type,object> (typeof(IntPtr),new IntPtr(6) ),
            new KeyValuePair<Type,object> (typeof(String),"Hello!" ),
        };
        public static object ConvertFromDBValue(Type type, object value)
        {
            try
            {
                switch (TypeDefs[type])
                {
                    case 1: // {typeof(Int16), 1},
                        {
                            return Convert.ToInt16(value);
                        }
                    case 2: // {typeof(Int32), 2},
                        {
                            return Convert.ToInt32(value);
                        }
                    case 3: // {typeof(Int64), 3},
                        {
                            return Convert.ToInt64(value);
                        }
                    case 4: // {typeof(IntPtr), 4},
                        {
                            return value;
                        }
                    case 5: // {typeof(Char), 17},
                    case 6: // {typeof(String), 18},
                        {
                            return value;
                        }
                    default:
                        {
                            return value;
                        }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static object ConvertFromDBValue2(Type type, object value)
        {
            try
            {
                if (type == typeof(Int16))
                {
                    return Convert.ToInt16(value);
                }
                if (type == typeof(Int32))
                {
                    return Convert.ToInt32(value);
                }
                if (type == typeof(Int64))
                {
                    return Convert.ToInt64(value);
                }
                if (type == typeof(IntPtr))
                {
                    return (IntPtr)value;
                }
                if (type == typeof(Char) || type == typeof(String))
                {
                    return value.ToString().Trim();
                }
                return value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        static Func<object, object>[] funcList =
        {
            (value) => value,                    //0
            (value) => Convert.ToInt16(value),   //1
            (value) => Convert.ToInt32(value),   //2
            (value) => Convert.ToInt64(value),   //3
            (value) => value,   //4
            (value) => value,   //5
            (value) => value,   //6
            (value) => value,   //7
            (value) => value,   //8
            (value) => value,   //9
            (value) => value,   //10
            (value) => value,   //11
            (value) => value,   //12
            (value) => value,   //13
            (value) => value,   //14
            (value) => value,   //15
            (value) => value,   //16
            (value) => value,   //17
            (value) => value.ToString().Trim() //18
        };
        public static object ConvertFromDBValueHogan(Type type, object value)
        {
        return funcList[TypeDefs[type]](value);
        }
        static void Main(string[] args)
        {
            var sw = new System.Diagnostics.Stopwatch();
            Random random = new Random(113453113);
            sw.Start();
            for (int i = 0; i < 10000000; i++)
            {
                var x = random.Next(5);
                var testValue = _Types[x];
                var p = ConvertFromDBValue(testValue.Key, testValue.Value);
            }
            var elapsed = sw.Elapsed;
            Console.WriteLine($"Dict+case: {elapsed.TotalMilliseconds}ms");
            sw.Restart();
            for (int i = 0; i < 10000000; i++)
            {
                var x = random.Next(5);
                var testValue = _Types[x];
                var p2 = ConvertFromDBValue2(testValue.Key, testValue.Value);
            }
            elapsed = sw.Elapsed;
            Console.WriteLine($"Ifs: {elapsed.TotalMilliseconds}ms");
            sw.Restart();
            for (int i = 0; i < 10000000; i++)
            {
                var x = random.Next(5);
                var testValue = _Types[x];
                var p3 = ConvertFromDBValueHogan(testValue.Key, testValue.Value);
            }
            elapsed = sw.Elapsed;
            Console.WriteLine($"Hogan's array of funcs: {elapsed.TotalMilliseconds}ms");
            Console.ReadLine();
        }
    }
