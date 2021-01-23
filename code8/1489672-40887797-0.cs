    var termQuery = new TermsQuery
    {
        Field = Infer.Field<Document>(d => d.Property1),
        Terms = new object[] { 1, 3, 5 }
    };
