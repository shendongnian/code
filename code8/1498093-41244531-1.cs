       public ReportingDbContext() : base("ReportingDbContext")
        {
            var objectContext = ((IObjectContextAdapter)this).ObjectContext;
            objectContext.SavingChanges += new EventHandler(OnSavingChanges);
        }
        public void OnSavingChanges(object sender, EventArgs e)
        {
            foreach (ObjectStateEntry entry in
                ((ObjectContext)sender).ObjectStateManager.GetObjectStateEntries(EntityState.Added | EntityState.Modified))
            {
                if (!entry.IsRelationship && (entry.Entity is ISerialize))
                {
                    (entry.Entity as ISerialize).Serialize();
                }
            }
        }
