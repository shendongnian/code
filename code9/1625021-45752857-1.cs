    #region Constructors
    public YourContext()
    {
    }
    public YourContext(DbContextOptions options) : base(options)
    {
    }
    #endregion Constructors
    #region DbSets
    #endregion DbSets
    #region OnConfiguring
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // In order to be able to create migrations and update database:
        if (!options.IsConfigured)
        {
            options.UseSqlServer("YourLocalConnectionStringShouldBeHere");
        }
        base.OnConfiguring(options);
    }
    #endregion
    #region Model Creating
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       // Your Model Crerating Stuff
    }
    #endregion Model Creating
