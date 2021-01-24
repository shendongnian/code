    var availableToField = Infer.Field<Project>(f => f.Availablity.AvailableTo);
    var availableFromField = Infer.Field<Project>(f => f.Availablity.AvailableFrom);
    var nameField = Infer.Field<Project>(f => f.Contact.Name);
    var active_date_to = new DateRangeQuery
    {
        Name = "toDate",
        Field = availableToField,
        GreaterThan = DateTime.Now,
        TimeZone = "+01:00",
        Format = "yyyy-MM-ddTHH:mm:SS||dd.MM.yyyy"
    };
    var active_date_from = new DateRangeQuery
    {
        Name = "from",
        Field = availableFromField,
        LessThanOrEqualTo = DateTime.Now,
        TimeZone = "+01:00",
        Format = "yyyy-MM-ddTHH:mm:SS||dd.MM.yyyy"
    };
    var ret = client.Search<Project>(s => s
        .Query(q =>
            +active_date_from &&
            +active_date_to && q
            .Match(d => d
                .Field(nameField)
                .Query("free text")
            )
        )
        .From(0)
        .Size(10)
    );
