    //Create some dummy data
    DataTable table = new DataTable();
    table.Columns.Add("GROUP_ID", typeof(string));
    table.Columns.Add("A_STRING", typeof(string));
    table.Columns.Add("AN_INT", typeof(int));
    table.Rows.Add("A", "this_is_A2", 7);
    table.Rows.Add("A", "this_is_A2", 4);
    table.Rows.Add("B", "this_is_B1", 3);
    table.Rows.Add("C", "this_is_C1", 1);
    table.Rows.Add("D", "this_is_D1", 3);
    table.Rows.Add("D", "this_is_D2", 2);
    var groups = (from dt in table.AsEnumerable()
                  group dt by dt.Field<string>("GROUP_ID") into g
                  select new { 
                      GroupID = g.Key, 
                      GroupData = g.Select(i => i.Field<int>("AN_INT")) }
                  ).ToList();
