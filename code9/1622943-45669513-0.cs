    public class Participant
    {
        public string firstName { get; set; }
        public string secondName { get; set; }
        public string gender { get; set; }
        public Participant(string firstName, string secondName, string gender)
        {
            this.firstName = firstName;
            this.secondName = secondName;
            this.gender = gender; 
        }
        public Participant(string[] args)
        {
            this.firstName = args[0];
            this.secondName = args[1];
            this.gender = args[2];
        }
    }
