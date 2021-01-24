    public System.Data.Entity.DbSet<TEntity> Set<TEntity>() where TEntity : 
    class
        {
    <#
    foreach (Table tbl in from t in tables.Where(t => !t.IsMapping && 
    t.HasPrimaryKey).OrderBy(x => x.NameHumanCase) select t)
    {
    #>
		
			if(typeof(TEntity) == typeof(<#=tbl.NameHumanCaseWithSuffix #>))
			{
				return <#=Inflector.MakePlural(tbl.NameHumanCase) #> as 
    System.Data.Entity.DbSet<TEntity>;
			}
       
    <# } #>
            throw new System.NotImplementedException("Doesn't have this table type!");
         }
