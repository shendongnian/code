    public class Service : IService1
    {
        public Fallible<Patient> GetPatient(int id)
        {
            return new Success<Patient>() { Value = new Patient() { Name = "Scott Robinson" } };
        }
    
        public List<Patient> GetPatients()
        {
            List<Patient> patients = new List<Patient>();
            patients.Add(new Patient() { Name = "Scott Robinson" });
            patients.Add(new Patient() { Name = "Darryl Robinson" });
            return patients;
        }
    
        public Fallible<List<Patient>> GetSpecificPatients(string type)
        {
            switch (type)
            {
                case "Fallible":
                    return new Fallible<List<Patient>>() { Value = new List<Patient>() { new Patient() { Name = "Scott" }, new Patient() { Name = "Darryl" } } };              
                default:
                    return new Success<List<Patient>>() { Value = new List<Patient>() { new Patient() { Name = "Scott" }, new Patient() { Name = "Darryl" } } };
            }
        }
    }
