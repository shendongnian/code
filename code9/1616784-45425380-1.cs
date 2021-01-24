    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    
    namespace ConsoleApp6
    {
    
        public class AppUser
        {
            public long Id { get; set; } // Id (Primary key)
        }
    
        public class AppUserRole
        {
            public long Id { get; set; } // Id (Primary key)
        }
    
        [Table("AppUserInRole", Schema = "dbo")]
        [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.31.1.0")]
        public partial class AppUserInRole
        {
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            [Column(@"Id", Order = 1, TypeName = "bigint")]
            [Required]
            [Key]
            [Display(Name = "Id")]
            public long Id { get; set; } // Id (Primary key)
    
            [Column(@"IdAppUser", Order = 2, TypeName = "bigint")]
            [Required]
            [Display(Name = "Id app user")]
            public long IdAppUser { get; set; } // IdAppUser
    
            [Column(@"IdAppUserRole", Order = 3, TypeName = "bigint")]
            [Required]
            [Display(Name = "Id app user role")]
            public long IdAppUserRole { get; set; } // IdAppUserRole
    
            [Column(@"ValidFrom", Order = 4, TypeName = "datetime2")]
            [Required]
            [Display(Name = "Valid from")]
            public System.DateTime ValidFrom { get; set; } = System.DateTime.Now; // ValidFrom
    
            [Column(@"ValidTo", Order = 5, TypeName = "datetime2")]
            [Display(Name = "Valid to")]
            public System.DateTime? ValidTo { get; set; } // ValidTo
    
            [Column(@"CreatedDate", Order = 6, TypeName = "datetime2")]
            [Required]
            [Display(Name = "Created date")]
            public System.DateTime CreatedDate { get; set; } = System.DateTime.Now; // CreatedDate
    
            [Column(@"CreatedBy", Order = 7, TypeName = "bigint")]
            [Required]
            [Display(Name = "Created by")]
            public long CreatedBy { get; set; } // CreatedBy
    
            // Foreign keys
    
            /// <summary>
            /// Parent AppUser pointed by [AppUserInRole].([CreatedBy]) (FK__AppUserIn__Creat__1AD3FDA4)
            /// </summary>
            [ForeignKey("CreatedBy")] public virtual AppUser AppUser_CreatedBy { get; set; } // FK__AppUserIn__Creat__1AD3FDA4
                                                                                             /// <summary>
                                                                                             /// Parent AppUser pointed by [AppUserInRole].([IdAppUser]) (FK__AppUserIn__IdApp__30F848ED)
                                                                                             /// </summary>
            [ForeignKey("IdAppUser")] public virtual AppUser AppUser_IdAppUser { get; set; } // FK__AppUserIn__IdApp__30F848ED
                                                                                             /// <summary>
                                                                                             /// Parent AppUserRole pointed by [AppUserInRole].([IdAppUserRole]) (FK__AppUserIn__IdApp__31EC6D26)
                                                                                             /// </summary>
            [ForeignKey("IdAppUserRole")] public virtual AppUserRole AppUserRole { get; set; } // FK__AppUserIn__IdApp__31EC6D26
        }
    
        [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.31.1.0")]
        public partial class AppUserInRoleConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<AppUserInRole>
        {
            public AppUserInRoleConfiguration()
                : this("dbo")
            {
            }
    
            public AppUserInRoleConfiguration(string schema)
            {
                Property(x => x.ValidTo).IsOptional();
    
                InitializePartial();
            }
            partial void InitializePartial();
        }
        class Db: DbContext
        {
            public Db(string nameOrConnectionString) : base(nameOrConnectionString)
            {
            }
    
            public DbSet<AppUserInRole> AppUserInRoles { get; set; }
    
            public async Task<List<AppUserInRole>> GetUserRoles(long userId, bool onlyValid)
            {
                var data = from d in this.AppUserInRoles
                           where d.IdAppUser == userId
                           select d;
    
                if (onlyValid)
                    data = data.Where(r => r.ValidFrom < DateTime.Now && (DateTime.Now < (r.ValidTo ?? DateTime.MaxValue)));
    
                return  await data.ToListAsync();
            }
    
        }
        class Program
        {
    
            static void Main(string[] args)
            {
    
                
    
    
                using (var db = new Db("Server=.;Database=foo;Integrated Security=true"))
                {
                    db.Database.Log = m => Console.WriteLine(m);
    
    
                    var data = db.GetUserRoles(1, true).Result;
                    
                }
      
                Console.ReadKey();
    
            }
        }
    }
