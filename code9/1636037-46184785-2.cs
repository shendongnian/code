    public class Person
    {
        public int PersonId { get; set; }
        public virtual ICollection<PersonClub> PersonClubs { get; set; }
    }
    public class Club
    {
        public int ClubId { get; set; }
        public virtual ICollection<PersonClub> PersonClubs { get; set; }
    }
    public class PersonClub
    {
        public int PersonId { get; set; }
        public Person Person { get; set; }
        public int ClubId { get; set; }
        public Club Club { get; set; }
    }
