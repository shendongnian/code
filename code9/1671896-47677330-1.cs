    public class SisterFiles 
    {
        public List<string> lstString;
    }
    public class FileGroups
    {
        public List<SisterFiles> lstSisterFiles;
    }
    class Program
    {
        static void Main(string[] args)
        {
            SisterFiles sisterFiles = new SisterFiles();
            sisterFiles.lstString.Add("My String");
            FileGroups fileGroup = new FileGroups();
            fileGroup.lstSisterFiles = new List<SisterFiles>();
            fileGroup.lstSisterFiles.Add(sisterFiles);
        }
    }
