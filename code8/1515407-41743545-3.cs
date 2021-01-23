    public class Candidate
    {
        [Key]
        public int CandidateId { get; set; }
        Column("firstname")]
        public string Firstname { get; set; }
        public virtual ICollection<SkillSet> SkillSets { get; set; }
    }
    public class SkillSet : SimpleDictionary
    {
        [Key]
        public int SkillSetId { get; set; }
        public virtual ICollection<Candidate> Candidates { get; set; }
    }
