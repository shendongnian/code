    public class DemoCls {
        IDirectoryService directory;
        public DemoCls(IDirectoryService directory) {
            this.directory = directory;
        }
        public void Execute(string dataFolder) {
            foreach (var x in directory.EnumerateFiles(dataFolder, "test*.xml")) {
                //...
            }
        }
    }
