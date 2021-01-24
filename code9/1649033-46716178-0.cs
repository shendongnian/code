    var dataTable = new DataTable();
    dataTable.TableName = "dbo.IntsTTV";
    dataTable.Columns.Add("Id", typeof(int));
    dataTable.Rows.Add(1); // Id of '1' is valid for the Person table
    SqlParameter parameter = new SqlParameter("UserIds", SqlDbType.Structured);
    parameter.TypeName = "dbo.IntsTTV";
    parameter.Value = dataTable;
    var res = _db.Database.SqlQuery<string>("EXEC dbo.GetUsers @UserIds", parameter).ToList();
