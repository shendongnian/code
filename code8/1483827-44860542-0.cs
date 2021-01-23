      public DataContext()
                : base(nameOrConnectionString)
            {
                Database.SetInitializer<DataContext>(null);
            }
