     public class JobID
    {
        public string jobname;
        public string first;
        public string second;
        public string third;
        public string clientName;
        public string workflow;
    }
    public class JobReader
    {
     // Property to store deserialized object
     public JobID Job { get; set; }
     public void load(string fname)
     {
         string s = File.ReadAllText(fname);
         // Assign object to property.
         this.JobID = JsonConvert.DeserializeObject<JobID>(s);    
     }
    } 
