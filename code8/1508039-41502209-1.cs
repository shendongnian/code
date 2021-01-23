    public partial class Team
    {
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public List<Player> TeamPlayers { get; set; }  //<-- have "team players"
        //public Nullable<int> TeamPower { get; set; } //Dont need this if teams are supposed to have equal powers.
    }
    
    public partial class Player
    {
        public int PlayerId { get; set; }        
        public Nullable<int> PlayerPower { get; set; }
    }
