    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ef62test
    {
        class Program
        {
    
            public class GameTable
            {
                [Key]
                [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
                public Guid Id
                {
                    get;
                    set;
                }
    
                [Required]
                public string Name { get; set; }
    
                [Required]
                public string Description { get; set; }
    
                public Guid CreatorId { get; set; }
    
                [ForeignKey(nameof(CreatorId))]
                public Account Creator { get; set; }
    
                [InverseProperty(nameof(Account.CurrentTable))]
                public ICollection<Account> CurrentPlayers { get; } = new HashSet<Account>();
            }
    
            public class Account
            {
                public Account()
                {
                    Elo = 1000;
                }
    
                [Key]
                [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
                public Guid Id { get; set; }
    
                [Required]
                [MaxLength(15)]
                [MinLength(4)]
                public string Name { get; set; }
    
                [Required]
                [MaxLength(32)]
                [MinLength(32)]
                public string PasswordHash { get; set; }
    
                public int Elo { get; set; }
    
                public bool IsAdmin { get; set; }
    
                public Guid? CurrentTableId { get; set; }
    
                [ForeignKey(nameof(CurrentTableId))]
                public virtual GameTable CurrentTable { get; set; }
    
                [InverseProperty(nameof(GameTable.Creator))]
                public ICollection<GameTable> CreatedTables { get; } = new HashSet<GameTable>();
            }
    
    
            public class MyDbContext : DbContext
            {
                public MyDbContext() : base("DbContextCon")
                {
                    Database.SetInitializer<MyDbContext>(new CreateDatabaseIfNotExists<MyDbContext>());
                }
    
                protected override void OnModelCreating(DbModelBuilder modelBuilder)
                {
                    base.OnModelCreating(modelBuilder);
                }
    
                public virtual DbSet<Account> Accounts { get; set; }
                //public virtual DbSet<SecurityToken> SecurityTokens { get; set; }
                public virtual DbSet<GameTable> GameTables { get; set; }
            }
            static void Main(string[] args)
            {
                Database.SetInitializer(new DropCreateDatabaseAlways<MyDbContext>());
                
                using (var db = new MyDbContext())
                {
                    db.Database.CreateIfNotExists();
                   
                }
    
    
    
                Console.WriteLine("Hit any key to exit.");
                Console.ReadKey();
            }
        }
    }
