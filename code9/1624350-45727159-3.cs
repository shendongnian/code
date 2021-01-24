    using System;
    using System.Linq;
    using System.Reflection;
    class Program
    {
        public static void Main(string[] args)
        {
            var props = typeof(MYClass).GetProperties().Where(prop => prop.IsDefined(typeof(MyAttribute), false));
            foreach (PropertyInfo propertyInfo in props)
            {
                Console.Out.WriteLine($"propertyInfo:" + Environment.NewLine +
                                      $"\tName = {propertyInfo.Name}," + Environment.NewLine +
                                      $"\tRepresentation = {propertyInfo}");
            }
        }
    }
