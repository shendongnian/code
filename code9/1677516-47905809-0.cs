    try
    {
        using (SqlConnection sqlConnection = new SqlConnection(DataSources.RemoteConnectionString()))
        {
            sqlConnection.Open();
            using (SqlCommand sqlCommand = new SqlCommand("[DB7934_businessmind].[DownloadAreaOfLaw]", sqlConnection))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@AoLId", aolid);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                sqlDataAdapter.SelectCommand = sqlCommand;
                sqlDataAdapter.Fill(aolDataSet.TempAoL);
                if (aolDataSet.TempAoL.Rows.Count > 0)
                {
                    using (SQLiteConnection sqliteConnection = new SQLiteConnection(DataSources.LocalConnectionString()))
                    {
                        sqliteConnection.Open();
    			
    					using(SqliteTransaction tr = sqliteConnection.BeginTransaction())
    					{
    						using (SQLiteCommand sqliteCommand = new SQLiteCommand(sqliteConnection))
    						{
    							foreach (Models.AoLDataSet.TempAoLRow r in aolDataSet.TempAoL.Rows)
    							{
    								sqliteCommand.CommandText = "INSERT INTO AreaOfLaw(AoLId, AreaOfLawTitle) VALUES(@AoLId, @AreaOfLawText)";
    								sqliteCommand.Parameters.AddWithValue("@AoLId", r.AoLId);
    								sqliteCommand.Parameters.AddWithValue("AreaOfLawText", r.AreaOfLawTitle);
    								sqliteCommand.ExecuteNonQuery();
    							}
    							sqliteCommand.Dispose();
    						}
    						
    						tr.Commit();
    					}
                        sqliteConnection.Close();
                    }
                }
            }
            sqlConnection.Close();
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show("An error has occurred while downloading Areas Of Law from the cloud, the original error is: " + ex.Message, "Area Of Law", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
