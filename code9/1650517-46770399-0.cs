    using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
    // ...
    modelBuilder.Entity<Person>(entity =>
    {
    	var pb = entity.Property(e => e.PersonId).ValueGeneratedOnAdd();
    	if (Database.IsInMemory())
    		pb.HasValueGenerator<InMemoryIntegerValueGenerator<decimal>>();
    });
