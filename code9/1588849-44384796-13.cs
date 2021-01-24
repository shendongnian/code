    public int Create() {
        SchemaBuilder.CreateTable("Port",
            table => table
                .Column<int>("Id", column => column.PrimaryKey().Identity())
                .Column<string>("MDN", column => column.NotNull().WithDefault(""))
                .Column<string>("Partner", column => column.NotNull().WithDefault(""))
            );
        return 1;
    }
