     var dataTable = new DataTable();
     dataTable.TableName = "idsList";
     dataTable.Columns.Add("Id", typeof(int));
     //here you add the ids of root persons you would like to get all persons under them
     dataTable.Rows.Add(1);
     dataTable.Rows.Add(2);
    //here we are creating the input parameter(which is array of ids)
     SqlParameter idsList = new SqlParameter("idsList", SqlDbType.Structured);
     idsList.TypeName = dataTable.TableName;
     idsList.Value = dataTable;
     //executing stored procedure
     var ids= dbContext.Database.SqlQuery<int>("exec getChildIds @idsList", idsList).ToList();
