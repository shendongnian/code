    public class Country
    {
        public string CountryName { get; set; }
        public int CountryId { get; set; }
        public List<State> States { get; set; }
    }
    public class State
    {
        public string StateName { get; set; }
        public int StateId { get; set; }
    }
