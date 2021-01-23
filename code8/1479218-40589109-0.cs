    ElasticClient db = new ElasticClient(uri);
    
                db.DeleteIndex(indexName);
    
                var mappings = new CreateIndexDescriptor(indexName).Mappings(ms => ms.Map<A>(map => map.
                    AutoMap().
                    Properties(props =>
                        props.String(p =>
                            p.Name(a => a.Text).
                            Fields(fields =>
                                fields.String(pr => pr.Name("raw").NotAnalyzed()))))));
    
                db.CreateIndex(mappings);
    
                foreach (var item in Enumerable.Range(0, 10).Select(i => new A
                {
                    Price1 = random.NextDouble() * 1000,
                    Date = i % 3 == 0 ? new DateTime(1900, 1, 1) : DateTime.Now,
                    Text = i % 2 == 0 ? "ABC" : "EFG"
                }))
                {
                    db.Index(item, inx => inx.Index(indexName));
                }
    
                var toDate = DateTime.Now + TimeSpan.FromDays(1);
                var fromDate = DateTime.Now - TimeSpan.FromDays(30);
    
                var data = db.Search<A>(s => 
                    s.Index(indexName)
                    .Query(q=>
                            q.DateRange(r => r.Field(f => f.Date).GreaterThan(fromDate).LessThanOrEquals(toDate))
                            &&
                            (
                            //term query is for finding words by default all words are lowercase but you can set a different analyzer
                            q.Term(t => t.Field(f => f.Text).Value("ABC".ToLower()))
                            ||
    //Raw field is not analysed so no need to lower case you can use you query here if you want
                            q.Term(t => t.Field("text.raw").Value("EFG"))
                            )
                    ).Aggregations(aggr => aggr.Terms("distinct", aterm => aterm.Field("text.raw"))));
