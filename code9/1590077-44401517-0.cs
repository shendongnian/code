    //Fluent
                client.Search<dynamic>(
                    s => s.
                    Index("idxsearch-test").
                    Type("movies").
                    Take(20).
                    Query(q => q.Bool(
                                  b => b.Must(m => m.Term(t => t.Field("tag.name").Value("Paris")) ||
                                                  m.MultiMatch(mm => mm.Fields(f => f.
                                                                                  Field("movie_title.default", 10).
                                                                                  Field("movie_title.snowball", 2).
                                                                                  Field("movie_title.shingles", 2).
                                                                                  Field("movie_title.ngrams")))).
                                          Filter(f => includeAdult ? f.Term(t => t.Field("is_adult").Value("")) : null))).
                     Source(sc => sc.Includes(i => i.Field("id_content").Field("movie_title").Field("vote_average").Field("tag.name").Field("is_adult"))));
    
                //Object
                client.Search<dynamic>(new SearchRequest<dynamic>("idxsearch-test", "movies")
                {
                    Size = 20,
                    Query = new BoolQuery
                    {
                        Must = new QueryContainer[]
                        {
                            new BoolQuery
                            {
                                Should = new QueryContainer[]
                                {
                                    new TermQuery() { Field = "tag.name", Value = "Paris" },
                                    new MultiMatchQuery
                                    {
                                        Fields = new [] { "movie_title.default^10", "movie_title.snowball^2", "movie_title.shingles^2", "movie_title.ngrams" }
                                    }
                                }
                            }
                        },
                        Filter = includeAdult ? new QueryContainer[]
                        {
                            new TermQuery { Field = "is_adult", Value = false }
                        } : null
                    },
                    Source = new Union<bool, ISourceFilter>(new SourceFilter { Includes = new[] { "id_content", "movie_title", "vote_average", "tag.name", "is_adult" } })
                });
