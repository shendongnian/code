    public void GetDataTabletFromCSVFile2(string csv_file_path, string tablenaam)
    {
        string cn = ConfigurationManager.ConnectionStrings["Scratchpad"].ConnectionString;
        using (SqlConnection dbConnection = new SqlConnection(cn))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = dbConnection;
                cmd.CommandType = CommandType.Text;
                // check if You really want test for table name, not tablenaam
                // mind that the column name is same as the DataTable's column name!!!!
                cmd.CommandText = $@"CREATE TABLE  test (
            [ID] INT IDENTITY (1, 1) NOT NULL, 
            [RunTimeGroupCheck] VARCHAR (1023) NULL, 
            CONSTRAINT [PK_Test] PRIMARY KEY CLUSTERED ([ID] ASC) 
            )";
                try
                {
                    dbConnection.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException e)
                {
                    MessageBox.Show(e.Message.ToString(), "Error Message");
                }
                finally
                {
                    dbConnection.Close();
                }
            }
        }
        string line;
        System.Data.DataTable csvData = new System.Data.DataTable();
        DataColumn firstColumn = new DataColumn("ID", typeof(int));
        firstColumn.AutoIncrement = true; // This is the thing that enables You to leave the ID column. It will autoincrement.
        firstColumn.AutoIncrementSeed = 1;
        firstColumn.AutoIncrementStep = 1;
        csvData.Columns.Add(firstColumn);
        csvData.Columns.Add(new DataColumn("RunTimeGroupCheck", typeof(string)));
        // Read the file and display it line by line.
        System.IO.StreamReader file = new System.IO.StreamReader(csv_file_path);
        while ((line = file.ReadLine()) != null)
        {
            DataRow newRow = csvData.NewRow();
            // missing filling of data. You need the line to be put somewhere.
            // also mind, that the newRow["ID"] is not set to anything.
            newRow["RunTimeGroupCheck"] = line;
            csvData.Rows.Add(newRow);
        }
        file.Close();
        InsertDataIntoSQLServerUsingSQLBulkCopy2(csvData, tablenaam);
    }
    static void InsertDataIntoSQLServerUsingSQLBulkCopy2(System.Data.DataTable csvFileData, string Tablename)
    {
        string cn = ConfigurationManager.ConnectionStrings["Scratchpad"].ConnectionString;
        using (SqlConnection dbConnection = new SqlConnection(cn))
        {
            dbConnection.Open();
            string sqlTrunc = "TRUNCATE TABLE " + Tablename;
            SqlCommand cmd = new SqlCommand(sqlTrunc, dbConnection);
            cmd.ExecuteNonQuery();
            using (SqlBulkCopy s = new SqlBulkCopy(dbConnection))
            {
                s.ColumnMappings.Clear();
                s.DestinationTableName = Tablename;
                foreach (var column in csvFileData.Columns)
                    s.ColumnMappings.Add(column.ToString(), column.ToString());
                s.WriteToServer(csvFileData);
                dbConnection.Close();
            }
        }
    }
