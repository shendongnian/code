    ElasticClient db = new ElasticClient(uri);
    
                var nestSearchRequest = db.Search<dynamic>(new SearchRequest(indexName)
                {
                    Query = new BoolQuery
                    {
                        Must = new QueryContainer[] { new TermQuery { Field = "name.first", Value = "shay" } },
                        Filter = new QueryContainer[] { new DateRangeQuery { Field = "postDate", GreaterThanOrEqualTo = new DateTime(2010, 3, 1), LessThan = new DateTime(2010, 4, 1) }, new PrefixQuery { Field = "name.second", Value = "ba" } }
                    }
                });
    
                var nestFluent = db.Search<dynamic>(
                    s => s.Index(indexName).Query(
                        q=>q.Bool(
                            bq=>bq.
                                Must(q.Term("name.first","shay")).
                                Filter(
                                    q.DateRange(drq => drq.Field("postDate").GreaterThanOrEquals(new DateTime(2010, 3, 1)).LessThan(new DateTime(2010, 4, 1))),
                                    q.Prefix("name.second", "ba")))));
    
                var lowLevelQuery = db.LowLevel.Search<dynamic>(indexName, new
                {
                    query = new
                    {
                        @bool = new
                        {
                            must = new { term = new Dictionary<string, string> { { "name.first", "shay" } } },
                            filter = new object[]
                            { 
                                new { range = new { postDate = new  { gte = new DateTime(2010, 3, 1), lt = new DateTime(2010, 4, 1) } } },
                                new { prefix = new Dictionary<string,string>{ { "name.second", "ba" }  } }
                            }
                        }
                    }
                });
    
                var rawJSON = db.LowLevel.Search<dynamic>(indexName, @"{""query"":{ ""bool"":{ ""must"":{ ""term"":{ ""name.first"":""shay"" } },""filter"":[{ ""range"":{ ""postDate"":{ ""gte"":""2010-03-01"",""lt"":""2010-04-01"" } } },{ ""prefix"":{ ""name.second"":""ba"" } }] } }}");
