    You can try this. works for me.
    
    public bool GetCountWithGroupby() {
            var result2 = _client.Search<Car>(s => s
            .Index("vehicles")
            .Type("car")
            .Aggregations(a => a
            .Terms("my_agg", st => st
                .Field(o => o.Color)
            )));
    
            var myAgg = result2.Aggregations.Terms("my_agg").Buckets;
    
            foreach (var bucket in myAgg)
            {
                Console.WriteLine($"key: {bucket.Key}, count: {bucket.DocCount}");
            }
            return true;
        }
