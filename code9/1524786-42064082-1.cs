    private static readonly string[] designationNames = {"PA","A","SA","M","SM","CON"};
    void Function()
    {
        /* ... */
        var resultSet = dt.Where(x => !String.IsNullOrEmpty(x.Field<String>("Project_Code")))
                .Select(x =>
                    new
                    {
                        Month = x.Field<String>("Month"),
                        ProjectCode = x.Field<String>("Project_Code"),
                        Designations = designationNames.ToDictionary(d => d, d => x.Field<int>(d))
                    }
                );
    }
