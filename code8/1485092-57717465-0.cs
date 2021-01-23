            Ignore(x => x.SysEndTime);
            Ignore(x => x.SysStartTime);
and insert/update works with DB still updating these columns as necessary to keep history.
Another way would be to setup the the column like so
Property(x => x.SysEndTime).IsRequired().HasColumnType("datetime2").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
