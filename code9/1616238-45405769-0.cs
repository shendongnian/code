    using System;
    using System.IO;
    using System.Xml.Serialization;
    namespace XmlPlayground
    {
        public class DataLogName
        {
            public DateTime DateLogged { get; set; }
            public string TaskName { get; set; }
            public string UserId { get; set; }
        }
        class Program
        {
            static void Main(string[] args)
            {
                var fileName = "myfile.txt";
                // TODO: Load File from text file
                var dateLogged = DateTime.Now;
                var taskName = "Example Task";
                var userId = "Fred1";
                // Populate structure
                var dataToSave = new DataLogName { DateLogged = dateLogged, TaskName = taskName, UserId = userId };
                // Save File
                var outputFileName = Path.GetFileNameWithoutExtension(fileName);
                using (var outFile = File.Create($@"SomeOtherFolder\{outputFileName}.xml"))
                {
                    var formatter = new XmlSerializer(typeof(DataLogName));
                    formatter.Serialize(outFile, dataToSave);
                }
            }
        }
    }
