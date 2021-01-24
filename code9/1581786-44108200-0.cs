    public class AdObject
    {
        [Key, Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string ObjectType { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DisplayName { get; set; }
        public string DistinguishedName { get; set; }
        [Key, Column(Order = 1)]
        public string PrimaryEmail { get; set; }
        public string Alias { get; set; }
        public string SamAccountName { get; set; }
        public string PrimaryDisplay { get; set; }
        public string CanonicalName { get; set; }
        public string OU { get; set; }
        public string CoreGroup { get; set; }
        public bool? IsDisabled { get; set; }
        public bool? IsForwarded { get; set; }
        public bool? DeliverAndRedirect { get; set; }
        public bool? DisableForwardAtLogon { get; set; }
        public DateTime? DisableAtLogonAfter { get; set; }
        public string Notify { get; set; }
        public DateTime? LastLogon { get; set; }
        public DateTime? LastApiLogon { get; set; }
        public DateTime? LastCheck { get; set; }
        
        public AdObject ForwardedToObject { get; set; }
        public ICollection<Forward> ForwardRecipientSchedule  { get; set; }
            = new List<Forward>();
        public ICollection<Forward> ForwardSchedule { get; set; }
            = new List<Forward>();
    }
    public class Forward
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public AdObject ForwardFromObject { get; set; }
        public AdObject ForwardToObject { get; set; }
        public bool? DeliverAndRedirect { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? StopTime { get; set; }
        public string Recurrence { get; set; }
        public bool? DisableForwardAtLogon { get; set; }
        public DateTime? DisableAtLogonAfter { get; set; }
        public string Notify { get; set; }
        public string StartJobId { get; set; }
        public string StopJobId { get; set; }
        public string StartJobStatus { get; set; }
        public string StopJobStatus { get; set; }
        public DateTime? StartJobCompleted { get; set; }
        public DateTime? StopJobCompleted { get; set; }
        public DateTime? StartJobCreated { get; set; }
        public DateTime? StopJobCreated { get; set; }
        public string StartReason { get; set; }
        public string StopReason { get; set; }
        
        
    }
    public class EntityContext : DbContext
    {
        public EntityContext() : base("name=EnityContext"){
        }
        
        public DbSet<AdObject> AdObjects { get; set; }
        public DbSet<Forward> Forwards { get; set; }
        //protected override void OnConfiguring(DbContext)
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdObject>()
                .HasMany(f => f.ForwardSchedule)
                .WithRequired(f => f.ForwardFromObject)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<AdObject>()
                .HasMany(f => f.ForwardRecipientSchedule)
                .WithRequired(f => f.ForwardToObject)
                .WillCascadeOnDelete(false);
            base.OnModelCreating(modelBuilder);
        }
    }
