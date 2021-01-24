    public class Batch
    {
        private string cendid;
        private string bmhfmc;
        public Batch() {}
        public Batch(string cendid, string bmhfmc)
        {
            this.cendid = cendid;
            this.bmhfmc = bmhfmc;
        }
        public string Cendid
        {
            get { return cendid; }
            set { cendid = value; }
        }
        public string Bmhfmc
        {
            get { return bmhfmc; }
            set { bmhfmc = value; }
        }
    }
