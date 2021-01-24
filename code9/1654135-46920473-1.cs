        DataTable tR = new DataTable();
        var result = from a in ta.AsEnumerable()
                     from b in tb.AsEnumerable()
                     .Where(b => a.Field<string>("StatudId") == b.Field<string>("StatusId")
                     && a.Field<string>("SubStatudId") == b.Field<string>("SubStatusId")
                     && a.Field<string>("Dubs") == "0"
                     )
                     select tR.LoadDataRow(new object[]
                     {
                          a.Field<string>("Address")
                         ,b.Field<string>("Status")
                         ,b.Field<string>("SubStatus")
                     }, false);
