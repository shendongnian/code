    class Ward
    {
        public string Name { get; set; }
    
        public List<Patient> Patients { get; set; }//array of patients as a property?
    
        public Ward(string name)
        {
            Name = name;
            Patients = new List<Patient>();
        }
    
        public string GetWardDetails()
        {
            return string.Format("{0}", Name);
        }
    }
