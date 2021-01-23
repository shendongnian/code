    public class TestClass
    {
        public static void TestMethod(String directory)
        {
            var files = System.IO.Directory.GetFiles(directory).Select(f => new FileInfo(f)).ToList();
            var numList = new[] { 1, 2 };
            var oneAndTwo = files.Where(fi => numList.Contains(fi.FileNumber)).ToList();
        }
    }
    public class FileInfo
    {
        public FileInfo()
        {
        }
        public FileInfo(String path)
        {
            Path = path;
        }
        public int FileNumber { get; private set; }
        private string _path;
        public String Path
        {
            get { return _path; }
            set
            {
                _path = value;
                FileNumber = GetNumberFromFileName(_path);
            }
        }
        public static int GetNumberFromFileName(string path)
        {
            int number;
            var fileName = System.IO.Path.GetFileName(path);
            string resultString = Regex.Match(fileName, @"\d+").Value;
            if (Int32.TryParse(resultString, out number))
            {
                return number;
            }
            else
            {
                throw new Exception(String.Format("No number present in the file {0}", path ?? "(null)"));
            }
        }
    }
