    namespace Client.iOS
    {
        public class FileHelper : IFileHelper
        {
            private string GetLocalFilePath(string filename)
            {
                string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                string libFolder = Path.Combine(docFolder, "..", "images", "Databases");
    
                if (!Directory.Exists(libFolder))
                {
                    Directory.CreateDirectory(libFolder);
                }
    
                return Path.Combine(libFolder, filename);
            }
            public byte[] ReadAllBytes(string filename)
            {
    			string path=GetLocalFilePath(filename);
                return (FileStream(path) as MemoryStream).ToArray();
            }
            private Stream FileStream(string path)
            {
                StreamReader lStreamReader = new StreamReader(path);
                MemoryStream lMemoryStream = new MemoryStream();
                lMemoryStream.Position = 0;
                lStreamReader.BaseStream.CopyTo(lMemoryStream);
                return lMemoryStream;
            }
        }
    }
