    dt = new DataTable();
            dt.Columns.Add("MemberID", typeof(int));
            dt.Columns.Add("YesterdayPounds", typeof(double));
            dt.Columns.Add("YesterdayTons", typeof(double));
            dt.Columns.Add("YesterdayDollars", typeof(double));
            dt.Columns.Add("TotalPounds", typeof(decimal));
            dt.Columns.Add("TotalTons", typeof(decimal));
            dt.Columns.Add("TotalDollars", typeof(string));
            dt.Rows.Add("1200", 10000.00, 500, 10000.00, 1000, 3000.00, 2000000.00);
            dt.Rows.Add("1200", 10000.00, 500, 10000.00, 1000, 3000.00, 2000000.00);
            dt.Rows.Add("1201", 10000.00, 500, 10000.00, 1000, 3000.00, 2000000.00);
            dt.Rows.Add("1202", 10000.00, 500, 10000.00, 1000, 3000.00, 2000000.00);
            var result = dt.AsEnumerable()
              .GroupBy(r => r.Field<int>("MemberID"))
              .Select(g =>
              {
                  var row = dt.NewRow();
                  row["MemberID"] = g.Key;
                  row["YesterdayPounds"] = g.Sum(r => r.Field<double>("YesterdayPounds"));
                  row["YesterdayTons"] = g.Sum(r => r.Field<double>("YesterdayTons"));
                  row["YesterdayDollars"] = g.Sum(r => r.Field<double>("YesterdayDollars"));
                  return row;
              }).CopyToDataTable();
            ds = new DataSet();
            
            ds.Tables.Add(dt);
            ds.Tables.Add(result);
            result.WriteXml(@"G:\MyDataset.xml");
