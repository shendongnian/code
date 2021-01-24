    using System.Data.Entity.ModelConfiguration.Configuration;
    
    public static partial class ConfigurationExtensions
    {
    	public static StringPropertyConfiguration IsEmailColumn(this StringPropertyConfiguration property)
    	{
    		return property.HasColumnType("varchar").HasMaxLength(255);
    	}
    }
