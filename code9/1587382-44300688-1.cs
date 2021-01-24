    public class DemoCls
    {
        private string _targetPath;
    
        public DemoCls(string targetPath){
            _targetPath = targetPath;
        }
        public void Execute(string targetPath)
        {
            foreach (string X in Directory.EnumerateFiles(targetPath, "test" + "*.xml"))
            {
            }
        }
    }
