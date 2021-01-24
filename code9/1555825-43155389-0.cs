    public ApplicationDbContext(string schemaname, string connString = "")
                : base(connString ?? whateverDefaultConnStringName)
            {
                SchemaName = schemaname;
                ((IObjectContextAdapter)this).ObjectContext.CommandTimeout = 180;
            }
      public ApplicationDbContext(string schemaname)
                : this(schemaname, System.Web.HttpContext?.Current?.Session?["ConnStringName"].ToString())
            {
            }
