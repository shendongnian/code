     modelBuilder.Entity<UserTag>()
        .HasRequired(x => x.UserGroup)
        .WithMany()  // I assume a 1 : many relation
        .Map(x =>
            // map the Foreignkey to the default naming convention
            x.MapKey("UserGroup_Id")  
            // add a Columnanotation, which you would place on the FK property, if you had one...
           .HasColumnAnnotation("UserGroup_Id", "Index", new IndexAnnotation(new IndexAttribute("UI_UserGroupTagtext", 2)
            {
                 IsUnique = true
            })));
      modelBuilder.Entity<UserTag>()
          .Property(x => x.TagText)
          // configure the length of the column in the database
          .HasMaxLength(128)
          // add the Unique index information - I used this column to be the first in the index
         .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("UI_UserGroupTagtext", 1)
          {
              IsUnique = true
          }));
