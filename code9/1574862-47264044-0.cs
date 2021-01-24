    using System;
    using System.Data;
    using System.Data.Common;
    
    namespace StackOverflowExamples
    {
        class AvailableDataProviders
        {
            public static void Main(string[] args)
            {
                using (DataTable providers = DbProviderFactories.GetFactoryClasses())
                {
                    Console.WriteLine("Available Data Providers:");
    
                    foreach (DataRow provider in providers.Rows)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Name: {0}", provider["Name"]);
                        Console.WriteLine("Description: {0}", provider["Description"]);
                        Console.WriteLine("Invariant Name: {0}", provider["InvariantName"]);
                        Console.WriteLine("AssemblyQualifiedName: {0}", provider["AssemblyQualifiedName"]);
                    }
                }
            }
        }
    }
