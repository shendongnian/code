                var ds = myDatabaseObject.Model.DataSources.Find("DW Connection");
                ds.Model.Tables.Add(new Table
                {
                    Name = "tablename",
                    Columns =
                    {
                        new DataColumn
                        {
                            Name = "Id",
                            DataType = DataType.Int64,
                            SourceColumn = "Id",
                            SourceProviderType = "BigInt",
                            IsUnique = true,
                            IsKey = true
                        },
                        new DataColumn
                        {
                            Name = "DateId",
                            DataType = DataType.DateTime,
                            SourceColumn = "DateId",
                            FormatString = "General Date",
                            SourceProviderType = "Date"
                        }
                        [...]
                    },
                    Partitions =
                    {
                        new Partition
                        {
                            Name = "Main",
                            DataView = DataViewType.Full,
                            Source = new QueryPartitionSource
                            {
                                DataSource = ds,
                                Query = query
                            }
                        }
                        [...]
                    }
                });
