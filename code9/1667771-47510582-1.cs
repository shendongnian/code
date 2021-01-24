    public class Race
    {
        public Race()
        {
        }
        public Race(Race r)
        {
            // copy constructor
            this.Id = r.Id;
            this.Owner = r.Owner;
            SetTeam(r.Team);
        }
        // ...
    }
