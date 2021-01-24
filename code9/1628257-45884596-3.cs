    public  class TestTest {
        private readonly IFilePath filePath;
      
        public TestTest (IFilePath filePath) {
            this.filePath = filePath;
        }
    
        public virtual string Test1() {
            string path = filePath.MapPath("folder", "filepath");
            return path;
        }
    }
