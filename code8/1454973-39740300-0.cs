    public DataTable GetSqlTable(string query)
    {
        using (SqlConnection dbConnection = new SqlConnection(@"Data Source={ServerName};Initial Catalog={DB_Name};UID={UserID}; Password={PWD}"))
        {
            dbConnection.Open();
            SqlDataAdapter da = new SqlDataAdapter(query, dbConnection);
            da.SelectCommand.CommandTimeout = 600000; //optional
            try
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                da.Update(dt);
                dbConnection.Close();
                return dt;
            }
            catch
            {
                dbConnection.Close();
                return null;
            }
        }
    }
    
    public void profilepicture()
    {
    	DataTable dt = GetSqlTable("/* some query */");
    	string number = "some value";
    	string defaultImg = "defaultImgPath";
    	if(dt.Rows.Count > 0)
    	{
    		string path = dt.Rows[0][0].ToString() + "\\" + number + ".jpg";
    		pictureEdit2.Image = Image.FromFile(File.Exists(path) ? path : defaultImg);
    	}
    	else
    	{
    		pictureEdit2.Image = Image.FromFile(defaultImg);
    	}
    }
