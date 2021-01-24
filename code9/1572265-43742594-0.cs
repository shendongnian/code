        public YourDBContext() : base("connstr") 
        {
            Database.SetInitializer<YourDBContext>(new DropCreateDatabaseAlways<YourDBContext>());
        }
        ...
    }
