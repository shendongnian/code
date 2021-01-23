	//using System.Data.SqlClient;
	//using System.Collections.Generic;
	public DataTable CreatePersonDataTable(IEnumerable<PersonDTO> people) 
	{
		//define the table
		var table = new DataTable("People");
		table.Columns.Add(new DataColumn("Name", typeof(string)));
		table.Columns.Add(new DataColumn("DOB", typeof(DateTime)));
		//populate it
		foreach (var person in people)
		{
			table.Rows.Add(person.Name, person.DOB);
		}
		return table;
	}
	
	readonly string ConnectionString; //set this in the constructor
	readonly int BulkUploadPeopleTimeoutSeconds = 600; //default; could override in constructor
	public IEnumerable<long> BulkUploadPeople(IEnumerable<PersonDTO> people) //you'd want to break this up a bit; for simplicty I've bunged everything into one big method
	{
		var data = CreatePersonDataTable(people);
		using(SqlConnection con = new SqlConnection(ConnectionString)) 
		{
			con.Open(); //keep same connection open throughout session
			RunSqlNonQuery(con, "select top 0 Name, DOB into #People from People");
			BulkUpload(con, data, "#People");
			var results = TransferFromTempToReal(con, "#People", "People", "Name, DOB", "Id");
			RunSqlNonQuery(con, "drop table #People");	//not strictly required since this would be removed when the connection's closed as it's session scoped; but best to keep things clean.
		}
        return results;
	}
	private void RunSqlNonQuery(SqlConnection con, string sql)
	{
		using (SqlCommand command = con.CreateCommand())
		{
			command.CommandText = sql;
			command.ExecuteNonQuery();		
		}
	}
	private void BulkUpload(SqlConnection con, DataTable data, string targetTable)
	{
		using(SqlBulkCopy bulkCopy = new SqlBulkCopy(con))
		{
			bulkCopy.BulkCopyTimeout = 600; //define this in your config 
			bulkCopy.DestinationTableName = targetTable; 
			bulkCopy.WriteToServer(data);		  
		}
	}
	private IEnumerable<long> TransferFromTempToReal(SqlConnection con, string tempTable, string realTable, string columnNames, string idColumnName)
	{
		using (SqlCommand command = con.CreateCommand())
		{
			command.CommandText = string.Format("insert into {0} output inserted.{1} select {2} from {3}", realTable, idColumnName, columnNames, tempTable);
			using (SqlDataReader reader = command.ExecuteReader()) 
			{
				while(reader.Read()) 
				{
					yield return r.GetInt64(0);
				}
			}
		}
	}
			
