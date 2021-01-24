    public class mock : FileOp, IFileWrapper
    {
        private string myPath { get; set; }
        internal mock(Boot boot, string myPath = "")
        {
            base.boot = boot;
            base.x = this;
            this.myPath = myPath;
        }
        public bool Exists(string path) => path == myPath;
    }
