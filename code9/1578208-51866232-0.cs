                DataTable table = new DataTable();
                table.Columns.Add(new DataColumn("FieldId", typeof(int)));
                table.Columns.Add(new DataColumn("Value", typeof(double)));
                foreach (Value v in NewRows)
                {
                    DataRow row = table.NewRow();
                    row["FieldId"] = v.FieldId;
                    row["Value"] = v.Value;
                    table.Rows.Add(row);
                }
                var param = new SqlParameter("@replacementValues", table) { TypeName = "dbo.CustomSqlType", SqlDbType = SqlDbType.Structured };
                await _dbContext.Database.ExecuteSqlCommandAsync("EXEC dbo.UpdateValues @replacementValues", param);
