                    // coordindex
                    var coordindex = new GlobalSecondaryIndex
                    {
                        IndexName = "coordindex",
                        ProvisionedThroughput = new ProvisionedThroughput
                        {
                            ReadCapacityUnits = (long)10,
                            WriteCapacityUnits = (long)1
                        },
                        Projection = new Projection { ProjectionType = "ALL" }
                    };
                    useridindex.KeySchema = FeedTbl.tableKeySchema3; 
