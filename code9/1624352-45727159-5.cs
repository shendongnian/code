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
                string newLine = Environment.NewLine;
                Console.Out.WriteLine($"propertyInfo:" + newLine +
                                      $"\tName = {propertyInfo.Name}," + newLine +
                                      $"\Format = {propertyInfo}" + newLine);
            }
        }
    }
