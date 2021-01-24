           IQueryable<Sales> query = null;
           StringBuilder Query = new StringBuilder();
            Query.Clear();
            Query.Append("select *" + Environment.NewLine);
            Query.Append("from" + Environment.NewLine);
            Query.Append("(" + Environment.NewLine);
            Query.Append("    select brand, item, sum(qty) as qty, ROW_NUMBER() over(partition by brand order by sum(qty) desc) as row_num" + Environment.NewLine);
            Query.Append("    from sales" + Environment.NewLine);
            Query.Append("    group by brand, item" + Environment.NewLine);
            Query.Append(")t" + Environment.NewLine);
            Query.Append("where row_num <= 3" + Environment.NewLine);
            Query.Append("order by brand asc, qty desc" + Environment.NewLine);
            DataTable dt = GetDataTable(db, Query.ToString());
            query = (
                    from rw in dt.AsEnumerable()
                    select new Sales
                    {
                        item = rw.Field<string>("item"),
                        brand = rw.Field<string>("brand"),
                        qty = rw.Field<int>("qty")
                    }
                  ).AsQueryable();
        public DataTable GetDataTable(DbContext context, string sqlQuery)
        {
            DbProviderFactory dbFactory = 
            DbProviderFactories.GetFactory(context.Database.Connection);
            using (var cmd = dbFactory.CreateCommand())
            {
                cmd.Connection = context.Database.Connection;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sqlQuery;
                using (DbDataAdapter adapter = dbFactory.CreateDataAdapter())
                {
                    adapter.SelectCommand = cmd;
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }
