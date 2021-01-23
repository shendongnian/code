    using System;
    using System.Data.Entity;
    using System.Windows.Forms;
    
    namespace Z.EntityFramework.Plus.Lab
    {
        public partial class Form_Issue_Audit_HeySatan : Form
        {
            public Form_Issue_Audit_HeySatan()
            {
                InitializeComponent();
    
                using (var ctx = new EntityContext())
                {
                    var audit = new Audit();
    
                    ctx.EntitySimples.Add(new EntitySimple {ColumnInt = 1});
    
                    ctx.SaveChanges(audit);
                }
            }
    
            public class EntityContext : DbContext
            {
                static EntityContext()
                {
                    AuditManager.DefaultConfiguration.AutoSavePreAction = (context, audit) =>
                    {
                        var Entities = context as EntityContext;
                        if (Entities != null)
                        {
                            Entities.AuditEntries.AddRange(audit.Entries);
                        }
                        else throw new InvalidOperationException($"Context is null for {context.Database.Connection}");
                    };
                }
    
                public EntityContext() : base("CodeFirstEntities")
                {
                }
    
                public DbSet<EntitySimple> EntitySimples { get; set; }
                public virtual DbSet<AuditEntry> AuditEntries { get; set; }
                public virtual DbSet<AuditEntryProperty> AuditEntryProperties { get; set; }
    
                protected override void OnModelCreating(DbModelBuilder modelBuilder)
                {
                    modelBuilder.Types().Configure(x => x.ToTable(GetType().DeclaringType != null ? GetType().DeclaringType.FullName.Replace(".", "_") + "_" + x.ClrType.Name : ""));
    
                    base.OnModelCreating(modelBuilder);
                }
            }
    
            public class EntitySimple
            {
                public int Id { get; set; }
                public int? ColumnInt { get; set; }
            }
        }
    }
