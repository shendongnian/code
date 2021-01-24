       private static void printPropertyNameValue(object obj, int intent)
        {
            foreach (var property in obj.GetType().GetProperties())
            {
                if (!property.CanWrite)
                    continue;
                var value = property.GetValue(obj);
                if (value != null && value.GetType().IsArray)
                {
                    Console.WriteLine("{0}{1}", "".PadLeft(intent, '-'), property.Name);
                    foreach (var item in ((Object[])value))
                    {
                        printPropertyNameValue(item, intent + 1);
                    }
                }
                else
                {
                    if (value != null && (value.GetType()).IsClass)
                    {
                        Console.WriteLine("{0}{1}", "".PadLeft(intent, '-'), property.Name);
                        printPropertyNameValue(property.GetValue(obj), intent + 1);
                    }
                    else
                    {
                        Console.WriteLine("{0}{1}:{2}", "".PadLeft(intent, '-'), property.Name, value);
                    }
                }
            }
        }
