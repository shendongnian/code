        public void BulkWrite(Dictionary<Int32, PhaseMag> data)
        {
            var dataTable = new DataTable();
            dataTable.Columns.Add(new DataColumn { DataType = typeof(int), ColumnName = "Key" });
            dataTable.Columns.Add(new DataColumn { DataType = typeof(Single), ColumnName = "Magnitude" });
            dataTable.Columns.Add(new DataColumn { DataType = typeof(Single), ColumnName = "Phase" });
            foreach (var x in data)
            {
                var r = dataTable.NewRow();
                dataTable.Rows.Add(r);
                r[0] = x.Key;
                r[1] = x.Value.Magnitude;
                r[2] = x.Value.Phase;
            }
            using (var conn = new SqlConnection("conneciton string"))
            {
                conn.Open();
                using (var bulkCopy = new SqlBulkCopy(conn))
                {
                    bulkCopy.BatchSize = 4000;
                    bulkCopy.DestinationTableName = "YorTableName";
                    bulkCopy.WriteToServer(dataTable);
                }
            }
        }
