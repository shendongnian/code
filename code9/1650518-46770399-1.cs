    using Microsoft.EntityFrameworkCore.Metadata
    using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
    // ...
    if (Database.IsInMemory())
    {
    	var autoGenDecimalProperies = modelBuilder.Model.GetEntityTypes()
    		.Select(t => t.FindPrimaryKey())
    		.Where(pk => pk != null)
    		.SelectMany(pk => pk.Properties)
    		.Where(p => p.ClrType == typeof(decimal) && p.ValueGenerated != ValueGenerated.Never);
    
    	foreach (var property in autoGenDecimalProperies)
    		property.SetValueGeneratorFactory((p, t) => new InMemoryIntegerValueGenerator<decimal>());
    }
