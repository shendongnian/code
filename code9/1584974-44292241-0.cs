                _client.DeleteByQuery<Employee>(s => s
                .Index(indexName)
                .Size(1000)
                .Query(q => q.
                    Bool(b => b.
                        MustNot(mn => mn.
                            QueryString(qs => qs.DefaultField("batchVersion").Query(newVersionId.ToString()))))));
