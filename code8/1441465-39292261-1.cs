    using System;
    using System.IO;
    using System.Reflection;
    
    namespace AutomateDigicall
    {
        class Program
        {
            static void Main(string[] args)
            {
                // Get current assembly
                var assembly = Assembly.GetExecutingAssembly();
                var resourceName = "AutomateDigicall.QAXXXXVBSFile.txt";
    
                string template = String.Empty;
    
                // Read resource from assembly
                using (Stream stream = assembly.GetManifestResourceStream(resourceName))
                using (StreamReader reader = new StreamReader(stream))
                {
                    template = reader.ReadToEnd();
                }
    
                // Write data in the new text file
                var filePath = "C:\\TestFolder\\myFileName.txt";
                using (TextWriter writer = File.CreateText(filePath))
                {
                    writer.WriteLine("Text from template below:");
                    writer.WriteLine(template);
                }
            }
        }
    }
