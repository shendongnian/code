    using System;
    using System.IO;
    using System.Reflection;
    namespace SqlScriptAsAResource
    {
        class Program
        {
            static void Main(string[] args)
            {
                Assembly myAssembly = Assembly.GetExecutingAssembly();
                Stream resStream = myAssembly.GetManifestResourceStream("SqlScriptAsAResource.MySqlScripts.sql");
                using(StreamReader reader = new StreamReader(resStream))
                {
                    String sqlScript = reader.ReadToEnd();
                    // Use your SQL script
                }
            }
        }
    }
