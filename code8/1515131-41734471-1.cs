    var query = from a in tableA
                        join b in tableB on a.Hid equals b.Hid into ab
                        select new
                        {
                            // Here is the call
                            TableType= ab.Select(t=>GetTableType(t.TableName)).FirstOrDefault(),
                            UserName = a.UserName,
                            Description = a.Description,
                            ImportedDate =   a.ImportedDate
                        };
