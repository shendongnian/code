    using System;
    using System.Reflection;
    using Microsoft.WindowsAPICodePack.Shell.PropertySystem;
    
    namespace ConsoleApplication1
    {
        internal class Program
        {
            private static void Main()
            {
                const string filePath1 = @"C:\Users\Mohammad\Downloads\Test\.....exe";
                var shellFile = Microsoft.WindowsAPICodePack.Shell.ShellObject.FromParsingName(filePath1);
                foreach (var propertyInfo in typeof(ShellProperties.PropertySystem).GetProperties(BindingFlags.Public | BindingFlags.Instance))
                {
                    var shellProperty = propertyInfo.GetValue(shellFile.Properties.System, null) as IShellProperty;
                    if (shellProperty?.ValueAsObject == null) continue;
                    var shellPropertyValues = shellProperty.ValueAsObject as object[];
                    if (shellPropertyValues != null && shellPropertyValues.Length > 0)
                    {
                        foreach (var shellPropertyValue in shellPropertyValues)
                            Console.WriteLine("{0} = {1}", propertyInfo.Name, shellPropertyValue);
                    }
                    else
                        Console.WriteLine("{0} = {1}", propertyInfo.Name, shellProperty.ValueAsObject);
                }
                Console.ReadKey();
            }
        }
    }
