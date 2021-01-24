      modelBuilder.Entity<baseGrammar>() 
     .Property(c => c.Id) 
     .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None); 
 
     modelBuilder.Entity<article>().Map(m => 
     { 
     m.MapInheritedProperties(); 
     m.ToTable("article"); 
     }); 
 
     modelBuilder.Entity<adjective>().Map(m => 
     { 
     m.MapInheritedProperties(); 
     m.ToTable("adjective"); 
     });
