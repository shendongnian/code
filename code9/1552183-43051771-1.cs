    //------------------------------
    static private bool boCreateDatabaseTables(string stPathFilename, 
                                               string stUserID, 
                                               string stPassword, 
                                               List<string> liststTableNames, 
                                               List<string> liststFieldDefinitions) 
    {
        bool boErrorFlag = false;
        int iTablesCount = liststTableNames.Count();
        string stOpenConn = new FbConnectionStringBuilder {
            Database = stPathFilename,
            UserID = stUserID,
            Password = stPassword,
            ServerType = FbServerType.Embedded,
            ClientLibrary = stCLIENT_LIBRARY
        }.ToString();
        using (FbConnection fbConn = new FbConnection(stOpenConn)) {
            try {
                fbConn.Open();
                FbTransaction fbTransaction = fbConn.BeginTransaction();
                for (int ii = 0; ii < iTablesCount; ii++) {
                    string stSql = "CREATE TABLE " + liststTableNames[ii] + "( " + liststFieldDefinitions[ii] + ")";
                    FbCommand fbCmd = new FbCommand(stSql, fbConn, fbTransaction);
                    fbCmd.ExecuteNonQuery();
                }
                fbTransaction.Commit();
            }
            catch (Exception ex) {
                boErrorFlag = true;
                MessageBox.Show("catch ... GlobalsFirebird ... boCreateDatabaseTables ... " + ex.Message);
            }
        }
        return boErrorFlag;
    }//boCreateDatabaseTables
    //------------------------------
    //------------------------------
    static public bool boAddRow(string stPathFilename,
                                string stUserID,
                                string stPassword,
                                string stTableName,
                                string stFieldNamesNoKeyId,
                                List<string> liststFieldValuesNoKeyId) 
    {
        bool boErrorFlag = false;
        string stOpenConn = new FbConnectionStringBuilder {
            Database = stPathFilename,
            UserID = stUserID,
            Password = stPassword,
            ServerType = FbServerType.Embedded,
            ClientLibrary = stCLIENT_LIBRARY
        }.ToString();
        using(FbConnection fbConn = new FbConnection(stOpenConn)) {
            fbConn.Open();
            try {
                string stValuesPlaceHolder = "@p0";
                for (int iii = 1; iii < liststFieldValuesNoKeyId.Count; iii++)
                    stValuesPlaceHolder += ", @p" + (iii).ToString();
                FbTransaction fbTransaction = fbConn.BeginTransaction();
                string stCmd = "INSERT INTO " + stTableName + "(" + stFieldNamesNoKeyId + ") VALUES ( " + stValuesPlaceHolder + " ) RETURNING  fiKeyID ";
                FbCommand fbCmd = new FbCommand(stCmd, fbConn, fbTransaction);
                for (int iii = 0; iii < liststFieldValuesNoKeyId.Count; iii++) {
                    string stPlaceHolder = "@p" + (iii).ToString();
                    string stValue = liststFieldValuesNoKeyId[iii];
                    fbCmd.Parameters.AddWithValue(stPlaceHolder, stValue);
                }
                fbCmd.Parameters.Add(new FbParameter() { Direction = System.Data.ParameterDirection.Output });
                fbCmd.ExecuteNonQuery();
                fbTransaction.Commit();
            }
            catch (Exception ex) {
                boErrorFlag = true;
                MessageBox.Show("catch ... GlobalsFirebird ... boAddRow ... " + ex.Message);
            }
        }
        return boErrorFlag;
    }//boAddRow
    //------------------------------        
