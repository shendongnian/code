    public class Program
    {
        public static void Main()
        {
            ComplexClass t = new ComplexClass()
            {
                x = DateTime.Now
            };
            object t2 = CloneProcedure(t);
            Console.WriteLine(t.x);
            Console.ReadLine();
        }
        private static object CloneProcedure(Object obj)
        {
            var type = obj.GetType();
            if (type.IsPrimitive || type.IsEnum || type == typeof(string))
            {
                return obj;
            }
            else if (type.IsClass || type.IsValueType)
            {
                object copiedObject = Activator.CreateInstance(obj.GetType());
                // Get all PropertyInfo.
                PropertyInfo[] properties = type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                foreach (PropertyInfo property in properties)
                {
                    object propertyValue = property.GetValue(obj);
                    if (propertyValue != null && property.CanWrite && property.GetSetMethod() != null)
                    {
                        property.SetValue(copiedObject, CloneProcedure(propertyValue));
                    }
                }
            }
            return obj;
        }
    
        public class ComplexClass
        {
            public DateTime x { get; set; }
        }
    }
