       public DateConvention()
        {
            Properties<DateTime>()
                .Where(x => x.GetCustomAttributes(false).OfType<DataTypeAttribute>()
                .Any(a => a.DataType == DataType.Date))
                .Configure(c => c.HasColumnType("date"));
            
        }
