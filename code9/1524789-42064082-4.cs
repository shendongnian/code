    private static readonly string[] designationNames = {"PA","A","SA","M","SM","CON"};
    
    void Function()
    {
        /* ... */
        var resultSet = dt.AsEnumerable().Where(x => !String.IsNullOrEmpty(x.Field<String>("Project_Code")))
            .Select(x =>
                designationNames.Select(
                    d =>
                        new
                        {
                            Month = x.Field<String>("Month"),
                            ProjectCode = x.Field<String>("Project_Code"),
                            Designation = d,
                            Count = x.Field<int>(d)
                        }
                )
            ).SelectMany(x => x).ToList();
    }
