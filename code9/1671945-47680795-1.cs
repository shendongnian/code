    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
 
        base.OnModelCreating(modelBuilder);
        
        //modelBuilder.Model.FindEntityType(typeof(Baz)).FindProperty("FooId").Relational().ColumnName = "Foo_FooId";
        foreach( var m in modelBuilder.Model.GetEntityTypes())
        {
            foreach (var sp in m.GetProperties().Where( p => p.IsShadowProperty ))
            {
                var fk = sp.GetContainingForeignKeys().Where(f => f.Properties.Count == 1).FirstOrDefault();
                if (fk != null && fk.PrincipalKey.Properties.Count == 1)
                {
                    sp.Relational().ColumnName = fk.PrincipalEntityType.Relational().TableName + "_" + fk.PrincipalKey.Properties.Single().Relational().ColumnName;
                }
            }
        }
    }
