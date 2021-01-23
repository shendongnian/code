    public class MyDocument
    {
        public DateTime DateOfBirth { get; set; }
    }
    var fluentMappingResponse = client.Map<MyDocument>(m => m
        .Index("index-name")
        .AutoMap()
        .Properties(p => p
            .Date(d => d
                .Name(n => n.DateOfBirth)
                .NullValue(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc))
            )
        )
    );
