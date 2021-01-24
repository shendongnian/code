    class Ward
    {
        public string Name { get; set; }
    
        public Patient[] Patients { get; private set; }
    
        public Ward(string name, IEnumerable<Patient> Patients)
        {
            Name = name;
            this.Patients = Patients.ToArray();
        }
        public Ward(string name, Patient[] Patients)
        {
            Name = name;
            Patients = Patients;
        }
    
        public string GetWardDetails()
        {
            return string.Format("{0}", Name);
        }
    }
