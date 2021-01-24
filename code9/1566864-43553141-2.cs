    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;
    
    namespace ConsoleApplication1
    {
        internal class Program
        {
            private static void Main(string[] args)
            {
                ConvertToXml(@"C:\test");
            }
    
            private static void ConvertToXml(string baseDirectory)
            {
                var root = new XElement("Root");
    
                var queue = new Queue<KeyValuePair<XElement, string>>();
                queue.Enqueue(new KeyValuePair<XElement, string>(root, baseDirectory));
    
                while (queue.Any())
                {
                    var pair = queue.Dequeue();
                    var path = pair.Value;
                    var element = pair.Key;
                    var directories = Directory.GetDirectories(path);
                    var files = Directory.GetFiles(path);
    
                    element.Add(
                        new XAttribute("Files", files.Length.ToString()),
                        new XAttribute("Directories", directories.Length.ToString()));
    
                    foreach (var directory in directories)
                    {
                        var directoryInfo = new DirectoryInfo(directory);
                        var directoryElement = new XElement("Directory",
                            new XAttribute("Name", directoryInfo.Name),
                            new XAttribute("Size", GetDirectorySize(directory)));
    
                        element.Add(directoryElement);
                        queue.Enqueue(new KeyValuePair<XElement, string>(directoryElement, directory));
                    }
    
                    foreach (var file in files)
                    {
                        var fileInfo = new FileInfo(file);
                        var fileElement = new XElement("File",
                            new XAttribute("Name", fileInfo.Name),
                            new XAttribute("Size", fileInfo.Length));
                        element.Add(fileElement);
                    }
                }
    
                var xml = root.ToString();
            }
    
            private static long GetDirectorySize(string path)
            {
                long length = 0;
    
                var queue = new Queue<string>(new[] {path});
    
                while (queue.Any())
                {
                    var value = queue.Dequeue();
    
                    var files = Directory.GetFiles(value);
                    length += files.Sum(s => new FileInfo(s).Length);
    
                    var directories = Directory.GetDirectories(value);
                    foreach (var directory in directories)
                        queue.Enqueue(directory);
                }
    
                return length;
            }
        }
    }
