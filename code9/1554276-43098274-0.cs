    public class ClassAMapping : ClassMap<ClassA>
    {
    	protected ClassAMapping()
    	{
    		Id(x => x.Id);
    		HasMany(x => x.Items).ForeignKeyConstraintName("none").KeyColumn("parent_id")                
                    .Where(string.Format("parent_type = '{0}'", typeof(ClassA).Name))
                    .Inverse()
                    .Cascade.AllDeleteOrphan();    		
    	}   
    }
    
    public class ClassBMapping : ClassMap<ClassB>
    {
    	protected ClassBMapping()
    	{
    		Id(x => x.Id);
    		HasMany(x => x.Items).ForeignKeyConstraintName("none").KeyColumn("parent_id")                
                    .Where(string.Format("parent_type = '{0}'", typeof(ClassB).Name))
                    .Inverse()
                    .Cascade.AllDeleteOrphan();    		
    	}   
    }
