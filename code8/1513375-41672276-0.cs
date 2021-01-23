    public class SuffixForeignKeyNameConvention : IStoreModelConvention<AssociationType>
    {
    	public SuffixForeignKeyNameConvention()
    	{
    	}
    public void Apply(AssociationType association, DbModel model)
    {
    	if (association.IsForeignKey)
    	{
    		AddSuffix(association.Constraint.ToProperties);
    	}
    }
    
    private void AddSuffix(IEnumerable<EdmProperty> properties)
    {
    	string result;
    	foreach (var property in properties)
    	{
    		result = property.Name;
    		
    		property.Name = $"{result}_ID";
    	}
    }
    }
