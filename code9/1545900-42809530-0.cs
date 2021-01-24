        using System;
        using System.Reflection;
        using System.Diagnostics.Contracts;
        // this is AssemblyB
        // residing at C:\TEMP\AssemblyB.dll
        namespace Com.Example.SO12188029.AssemblyB
        {
            public class ClassB
            {
                public string Property { get; set; } = "tralala";
            }
        }
        // this is AssemblyA
        // residing at C:\SomeWhereElse\AssemblyA.dll
        namespace Com.Example.SO12188029.AssemblyA
        {
            public class ClassA
            {
                private const string assemblyBPathAndFileName = @"C:\TEMP\AssemblyB.dll";
                private const string typeFromAssemblyBToBeInstantiated = @"Com.Example.SO12188029.AssemblyB.ClassB";
                
                public static void Main(string[] args)
                {
                    // try to load assembly
                    var assembly = Assembly.LoadFrom(assemblyBPathAndFileName);
                    Contract.Assert(null != assembly, assemblyBPathAndFileName);
                    
                    // make sure type exists in assembly
                    var type = assembly.DefinedTypes.First(e => e.IsClass && !e.IsAbstract
                        && e.FullName == typeFromAssemblyBToBeInstantiated);
                    Contract.Assert(null != type, typeFromAssemblyBToBeInstantiated);
                    
                    // try to get instance of type
                    var instance = Activator.CreateInstance(assembly.ManifestModule.FullyQualifiedName, typeFromAssemblyBToBeInstantiated);
                    
                    // ... now we have an instance, but as long as you do not know what *kind* of instance this is
                    // you cannot do much with it, unless - we use reflection to get access to the instance
                    
                    var propertyInfo = instance.GetType().GetProperty("Property");
                    var propertyValue = propertyInfo.GetValue(instance);
                    
                    Console.WriteLine("ClassB.PropertyValue '{0}'", propertyValue);
                }
            }
        }
