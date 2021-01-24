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
            JobID tmp = JsonConvert.DeserializeObject<JobID>(s);
            copy(tmp);
        }
        public void copy(JobID tmp)
        {
            this.jobname = tmp.jobname;
            // do the same for other properties that you want to copy
        }
    }
