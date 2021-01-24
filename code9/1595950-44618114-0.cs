    public class Race
    {
        public int ID { get; set; }
        public virtual ICollection<RaceParticipation> Participants { get; set; }
     }
    public class Driver
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<RaceParticipation> Races { get; set; }
    }
    public class RaceParticipation
    {
        public int ID {get;set;}
        public Race Race {get;set;}
        public Driver Driver {get;set;}
        // maybe information like this:
        public int StartingPosition {get;set;}
        public int FinalPosition {get;set;}
    }
