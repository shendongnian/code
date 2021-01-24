        class C
        {
            public int Id { get; set; }
            public string Description { get; set; }
            [BsonRepresentation(BsonType.Decimal128)]
            public decimal Amount { get; set; }
        }
