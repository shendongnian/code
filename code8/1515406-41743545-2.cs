    [Table("candidate")]
    public class Candidate
    {
        [Key]
        public int CandidateId { get; set; }
        Column("firstname")]
        public string Firstname { get; set; }
        [Table("candidate_skillset")] // how to define junction table name
        public virtual ICollection<SkillSet> SkillSets { get; set; }
    }
    [Table("skillset")]
    public class SkillSet : SimpleDictionary
    {
        [Key]
        public int SkillSetId { get; set; }
        [Table("candidate_skillset")] // how to define junction table name
        public virtual ICollection<Candidate> Candidates { get; set; }
    }
    [Table("candidate_skillset")]
    public class CandidateSkillset
    {
        [Key]
        [Column(Order = 1)]
        [ForeignKey("SkillSet")]
        public int SkillSetId { get; set; }
        [Key]
        [Column(Order = 2)]
        [ForeignKey("Candidate")]
        public int CandidateId { get; set; }
        public SkillSet SkillSet { get; set; }
        public Candidate Candidate { get; set; }
    }
