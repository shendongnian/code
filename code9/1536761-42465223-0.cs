        ...
                        filter = new object[]
                        {
                          new {
                            terms = new
                            {
                                SourceId = new[] {10,11,12}
                            }
                          },
                          new {
                            range = new
                            {
                                PostPubDate = new
                                {
                                    gte = "2015-10-01T00:00:00",
                                    lte = "2015-11-01T12:00:00"
                                }
                            }
                          }
                        }
