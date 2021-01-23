    using System;
    using System.Reflection;
    using System.IO;
    using System.Diagnostics;
    namespace YourProject
    {
        public class MyClass
        {
            // Other Code...
            private void StartProcessWithFile()
            {
                var assembly = Assembly.GetExecutingAssembly();
                //Getting names of all embedded resources
                var allResourceNames = assembly.GetManifestResourceNames();
                //Selecting first one. 
                var resourceName = allResourceNames[0];
                var pathToFile = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory) +
                                  resourceName;
    
                using (var stream = assembly.GetManifestResourceStream(resourceName))
                using (var fileStream = File.Create(pathToFile))
                {
                    stream.Seek(0, SeekOrigin.Begin);
                    stream.CopyTo(fileStream);
                }
    
                var proccess = new Process();
                process.StartInfo.FileName = pathToFile;
                process.Start();
            }
        }
    }
