    public class Relative
    {
        public Relative()
        {
            Patients = new Collection<Patient>();
        }
        public int Id { get; set; }
        public ICollection<Patient> Patients { get; set; }
    }
    
    public class Patient
    {
        public Patient()
        {
            Relatives  = new Collection<Relative>();
        }
        public int Id { get; set; }
        public ICollection<Relative> Relatives { get; set; }
    }
