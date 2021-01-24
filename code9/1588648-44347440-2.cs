    class Sample
    {
        [Text(Norms = false)]
        public string FirstName { get; set; }
        [Text(Norms = false)]
        public string LastName { get; set; }
    }
    client.CreateIndex(indexName,
        create => create.Mappings(
            mappings => mappings.Map<Sample>(
                map => map.AutoMap()
            )
        )
    );
