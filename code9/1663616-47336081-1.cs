    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    //using Microsoft.Samples.EFLogging;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;
    
    
    namespace EFCore2Test
    {
        public class Question
        {
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Id { get; set; }
    
            public virtual int? RightAnswerId { get; set; }
    
            [ForeignKey("Id,RightAnswerId")]
            public virtual AnswerOption RightAnswer { get; set; }
    
            public virtual ICollection<AnswerOption> AnswerOptions { get; set; }
        }
    
        public class AnswerOption
        {       
            public int QuestionId { get; set; }
    
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Id { get; set; }
    
            [InverseProperty("AnswerOptions")]
            public virtual Question Question { get; set; }
        }
        public class Db : DbContext
        {
            public DbSet<Question> Questions { get; set; }
            public DbSet<AnswerOption> AnswerOptions { get; set; }
    
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<AnswerOption>().HasKey(e => new { e.QuestionId, e.Id });
                base.OnModelCreating(modelBuilder);
            }
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer("Server=(local);Database=Test2;Trusted_Connection=True;MultipleActiveResultSets=true");
                base.OnConfiguring(optionsBuilder);
            }
        }
    
    
    
    
        class Program
        {
    
    
            static void Main(string[] args)
            {
                 using (var db = new Db())
                {
    
                    db.Database.EnsureDeleted();
                   // db.ConfigureLogging(s => Console.WriteLine(s));
                    db.Database.EnsureCreated();
                    for (int i = 0; i < 100; i++)
                    {
                        var q = new Question();
                        db.Questions.Add(q);
    
                        var a = new AnswerOption();
                        a.Question = q;
                        var b = new AnswerOption();
                        b.Question = q;
                        db.SaveChanges();
    
                        q.RightAnswer = a;
                        db.SaveChanges();
                    }
    
                }
    
                Console.WriteLine("Hit any key to exit");
                Console.ReadKey();
            }
        }
    }
