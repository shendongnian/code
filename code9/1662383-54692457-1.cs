    if (Database.IsNpgsql())
    {
        var converter = new ValueConverter<byte[], long>(
            v => BitConverter.ToInt64(v, 0),
            v => BitConverter.GetBytes(v));
    
        builder.Entity<Author>()
                .Property(_ => _.RowVersion)
                .HasColumnName("xmin")
                .HasColumnType("xid")
                .HasConversion(converter);
    }
