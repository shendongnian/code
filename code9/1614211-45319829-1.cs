    public partial class Patient
    {
        public Patient(Patient p)
        {
            this.FIRSTNAME = p.FIRSTNAME;
            this.MIDDLENAME = p.MIDDLENAME;
            this.SURNAME = p.SURNAME;
        }
    }
