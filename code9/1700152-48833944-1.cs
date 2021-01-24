            var mappings = mappingTable.Rows.Cast<DataRow>()
                .Select(
                    r => new DataMapping
                    {
                        Name = r.Field<string>("Name"),
                        Id = r.Field<int>("id"),
                        ParentId = r.Field<int>("parentID"),
                    }).ToList();
            var data = dataTable.Rows.Cast<DataRow>()
                .Select(
                    r => new DataModel
                    {
                        Name = r.Field<string>("Name"),
                        America = Convert.ToInt32(r.Field<string>("America")),
                        Japan = Convert.ToInt32(r.Field<string>("Japan")),
                        Singapore = Convert.ToInt32(r.Field<string>("Singapore")),
                        Id = mappings.Single(m => m.Name.Equals(r.Field<string>("Name"))).Id
                    }).ToList();
