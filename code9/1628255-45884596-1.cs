    public  class TestTest {
        private readonly IServerPath filePath;
      
        public TestTest (IServerPath filePath) {
            this.filePath = filePath;
        }
    
        public virtual string Test1() {
            string path = filePath.MapPath("folder", "filepath");
            return path;
        }
    }
