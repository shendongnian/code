     var dataTable = new DataTable();
     dataTable.TableName = "idsList";
     dataTable.Columns.Add("Id", typeof(int));
     dataTable.Rows.Add(1);
     dataTable.Rows.Add(2);
    
      SqlParameter idsList = new SqlParameter("idsList", SqlDbType.Structured);
      idsList.TypeName = dataTable.TableName;
      idsList.Value = dataTable;
    
      var results = dbContext.Database.SqlQuery<int>("exec getChildIds @idsList", idsList).ToList();
