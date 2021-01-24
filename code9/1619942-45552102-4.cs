    var documents = (new[]
    {
        new Document
        {
            Id = 1,
            Fields = new[]
            {
                new DocumentField { Id = 32, StringValue = "CET20533" },
                new DocumentField { Id = 16, StringValue = "882341" },
                new DocumentField { Id = 12, FloatValue = 101746F },
            }
        },
        new Document
        {
            Id = 2,
            Fields = new[]
            {
                new DocumentField { Id = 32, StringValue = "Bla" },
                new DocumentField { Id = 16, StringValue = "882341" },
                new DocumentField { Id = 12, FloatValue = 101746F },
            }
        }
    }).AsQueryable();
    var matches = documents.HavingAllFields(fieldPredicates).ToList();
