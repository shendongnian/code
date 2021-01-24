    class MyDbcontext : DbContext
    {
        ...
        public DbModelInfo DbModelInfo {get; set;}
        public override void OnModelCreating(...)
        {
            // if no model info set, use default
            if (this.DbModelInfo == null)
               this.DbModelInfo = DbModelInfo.Default;
            // set precision of all decimals:
            modelBuilder.Properties<decimal>()
                .Configure(decmal => decmal.HasPrecision(
                    this.DbModel.DecimalPrecision, 
                    this.DbModel.DecimalScale));
            // set type of all DateTime:
            modelBuilder.Properties<DateTime>()
                .Configure(datTime => datTime.HasColumnType(this.DbModel.DateTimeType));
        }
    }
