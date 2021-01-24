    public class UserSkill
    {
        public string Skill { get; set; }
        public int SkillLevel { get; set; }
        public bool IsInterested { get; set; }
        public string Interested => IsInterested ? "Y" : "N";
    }
