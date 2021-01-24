    private void foo()
    {
        // add a much conditions as you can inside the query
        // for example "SELECT * FROM TableName WHERE Col2 IS NOT NULL AND col2 LIKE '%jr%' AND col3 > 3 AND YEAR(col4) = 2017"...
        string SqlString = "SELECT * FROM TableName";
        SqlDataAdapter sda = new SqlDataAdapter(SqlString, Conn);
        DataTable dt = new DataTable();
        try
        {
            Conn.Open();
            sda.Fill(dt);
            // you can add more conditions, filterring, sorting, grouping using LINQ or Lambda Expretions
            // for example create new datatable based on condition
            DataTable newDt = dt.AsEnumerable().Where(x => x.Field<int>("col3") > 3).Select(y => y).CopyToDataTable();
    
            // use WriteToXml() method and save as xml file
            string FilePath = @"C:\YOUR_FILE_PATH.xml";
            // give name to the datatable, WriteToXml() can not create xml with null table name
            newDt.TableName = "myTableName";
            // save
            newDt.WriteXml(FilePath);
    
        }
        catch (SqlException se)
        {
            DBErLog.DbServLog(se, se.ToString());
        }
        finally
        {
            Conn.Close();
        }
    }
