    public class JobID
    {
        public string jobname;
        public string first;
        public string second;
        public string third;
        public string clientName;
        public string workflow;
            
        public void load(string fname)
        {
            string s = File.ReadAllText(fname);
            new JsonSerializer().Populate(new JsonTextReader(new StringReader(s)), this);
        }
    }
