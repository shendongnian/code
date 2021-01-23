    var result = dtLists.AsEnumerable()
            .GroupBy(m => new
            {
                ListID = m.Field<int>("ListID"),
                ListName = m.Field<string>("ListName")
            }, m => m)
            .Select(m => new
            {
                m.Key.ListID,
                m.Key.ListName,
                Tags = m.Select(x => new { x.Field<int>("TagId"), x.Field<string>("TagValue") })
            });
