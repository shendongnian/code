    public class Player
    {
        public int Id { get; set; }
        public string PlayerName { get; set; }
        public virtual List<PlayerSkill> PlayerSkills { get; set; }
    }
