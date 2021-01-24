    public class mock : FileOp, IFileWrapper
    {
        private string myPath { get; set; }
        internal mock(string myPath = "")
        {
            base.x = this;
            this.myPath = myPath;
        }
        public bool Exists(string path) => path == myPath;
    }
