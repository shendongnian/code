    var sch = new JSchema()
    {
        Type = JSchemaType.Object,
        AllowAdditionalProperties = false,
        Properties =
        {
            {
                "Username",
                new JSchema() { Type = JSchemaType.String }
            }
        },
    };
    sch.Required.Add("Username");
