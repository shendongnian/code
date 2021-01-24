        private static void Main(string[] args)
        {
            var dt = new DataTable();
            var col = new DataColumn { DataType = typeof(int), ColumnName = "ID" }; dt.Columns.Add(col);
            col = new DataColumn { DataType = typeof(string), ColumnName = "Desc" }; dt.Columns.Add(col);
            col = new DataColumn { DataType = typeof(int), ColumnName = "tID" }; dt.Columns.Add(col);
            var row = dt.NewRow();
            {
                row["ID"] = 1;
                row["Desc"] = "This is description";
                row["tID"] = 2;
            }
            dt.Rows.Add(row);
            var dto = ToDTO<UpdatedDto>(dt);
            //var dw = new DataView(dt);
            //var dtUnique = dw.ToTable(true, "col1", "col2", "col3");
        }
        private static List<object> ToDTO<T>(DataTable dt)
        {
            var reult = (from rw in dt.AsEnumerable()
                         select new UpdatedDto
                         {
                             ID = Convert.ToInt32(rw["ID"]),
                             Desc = Convert.ToString(rw["Desc"]),
                             tID = Convert.ToInt32(rw["tID"])
                         }).ToList();
            return reult.ConvertAll<object>(o => (object)o);
        }
