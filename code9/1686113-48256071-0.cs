    public class JobID
    {
        public string jobname;
        public string first;
        public string second;
        public string third;
        public string clientName;
        public string workflow;
        public static JobId Load(string fname){
            string s = File.ReadAllText(fname);
            return JsonConvert.DeserializeObject<JobID>(s);    
        }
    }
