    using System;
    using System.IO;
    using System.Reflection.Metadata;
    using System.Reflection.PortableExecutable;
    namespace MetadataTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                using (var stream = File.OpenRead(args[0]))
                using (var peFile = new PEReader(stream))
                {
                    var metadataReader = peFile.GetMetadataReader();
                    foreach (var type in metadataReader.TypeDefinitions)
                    {
                        var definition = metadataReader.GetTypeDefinition(type);
                        var name = metadataReader.GetString(definition.Name);
                        var ns = metadataReader.GetString(definition.Namespace);
                        Console.WriteLine(ns + "." + name);
                    }
                }
            }
        }
    }
