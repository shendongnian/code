    public class FileTreeManager
    {
        private DirectoryInfo mDirectoryInfo;
        public FileTreeManager(string aEntryPoint)
        {
            SetEntryPoint(aEntryPoint);
        }
        public void SetEntryPoint(string aEntryPoint)
        {
            this.mDirectoryInfo = new DirectoryInfo(aEntryPoint);
        }
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            foreach (DirectoryInfo dir in this.mDirectoryInfo.EnumerateDirectories())
            {
                result.Append("|-- " + dir.Name + Environment.NewLine);
            }
            return result.ToString();
        }
    }
