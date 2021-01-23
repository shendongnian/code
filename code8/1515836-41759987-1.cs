     using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace ConsoleApplication1
    {
        public class SampleDbContext : DbContext
        {
            public SampleDbContext()
                : base("name=SampleDBConnection")
            {
                this.Configuration.LazyLoadingEnabled = false;
            }
            public DbSet<Candidate> Candidates { get; set; }
            public DbSet<SkillSet> SkillSets { get; set; }
            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Candidate>().HasMany(t => t.SkillSets).WithMany(t => t.Candidates)
            .Map(m =>
            {
                m.ToTable("candidate_skillset");
                m.MapLeftKey("candidate_id");
                m.MapRightKey("skillset_id");
            });
                modelBuilder.Entity<SkillSet>().ToTable("skillset");
                modelBuilder.Entity<Candidate>().ToTable("candidate");
            }
        }
        [Table("candidate")]
        public class Candidate
        {
            public Candidate()
            {
                this.SkillSets = new HashSet<SkillSet>();
            }
            [Key]
            public int id { get; set; }
            [Column("firstname")]
            public string Firstname { get; set; }
            public int? commendation_id { get; set; }
            //[ForeignKey("commendation_id")]
            //public Commendation commendation { get; set; }
            public ICollection<SkillSet> SkillSets { get; set; }
        }
        public class SimpleDictionary
        {
            [Key]
            public int id { get; set; }
            [Column("name")]
            public string Name { get; set; }
        }
        [Table("skillset")]
        public class SkillSet : SimpleDictionary
        {
            public SkillSet()
            {
                this.Candidates = new HashSet<Candidate>();
            }
            public virtual ICollection<Candidate> Candidates { get; set; }
        }
    }
