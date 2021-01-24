    public class DemoCls
    {
        public void Execute(string targetPath)
        {
            foreach (string X in Directory.EnumerateFiles(targetPath, "test" + "*.xml"))
            {
            }
        }
    }
