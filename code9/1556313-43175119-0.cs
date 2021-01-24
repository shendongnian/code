            builder.ToTable("books_tags_link");
            base.Map(builder);
            builder.HasKey(x => new {x.TagId, x.BookId });
            builder.HasOne(bt => bt.Book)
                .WithMany(b => b.BookTagLinks)
                .HasForeignKey(bt => bt.BookId);
            builder.HasOne(bt => bt.Tag)
                .WithMany(t => t.BookTagLinks)
                .HasForeignKey(bt => bt.TagId);
            builder.Property(b => b.BookId)
                .ForSqliteHasColumnName("book")
                .IsRequired();
            builder.Property(b => b.TagId)
                .ForSqliteHasColumnName("tag")
                .IsRequired();
            
        }`
