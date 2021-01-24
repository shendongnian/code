    var o = new
                {
                    size = 20,
                    query = new
                    {
                        @bool = new
                        {
                            must = new
                            {
                                query_string = new
                                {
                                    fields = new[] { "Title" },
                                    query = search_query
                                }
                            },
                            filter = new
                            {
                                terms = new
                                {
                                    SourceId = new[] {10,11,12}
                                }
                            }
                        }
                    }                
                };
