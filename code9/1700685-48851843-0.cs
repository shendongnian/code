        class Program
        {
            static void Main()
            {
                foreach (var field in typeof(TableName).GetFields(BindingFlags.Static | BindingFlags.Public))
                {
                    ProcessField(field);
                }
            }
            static void ProcessField(FieldInfo field)
            {
                ProcessD(field.GetCustomAttribute(typeof(DescriptionAttribute)) as DescriptionAttribute);
                ProcessDWV(field.GetCustomAttribute(typeof(DescriptionWithValueAttribute)) as DescriptionWithValueAttribute);            
            }
            static void ProcessD(DescriptionAttribute attribute)
            {
                if(attribute != null)
                {
                    //...
                }
            }
            static void ProcessDWV(DescriptionWithValueAttribute attribute)
            {
                if (attribute != null)
                {
                    //...
                }
            }
