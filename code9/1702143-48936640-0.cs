    private async void button1_Click(object sender, EventArgs e)
        {
            try
            { 
                using (OleDbConnection dbConn = new OleDbConnection(SQLWrapper.CONNECT_STRING))
                {
                    dbConn.Open();
                    OleDbTransaction dbTrans = dbConn.BeginTransaction();
                    var taskName = sql.executeAsync("UPDATE Config SET Busname = @name", dbConn, dbTrans,
                         new OleDbParameter("@name", "name"));
                    var taskInsert = sql.executeAsync("INSERT INTO Callout VALUES (16, 'ryanistesting')", dbConn, dbTrans);
                    await Task.WhenAll(taskName, taskInsert);
                    dbTrans.Commit();
                }
            }
        }
        public async Task executeAsync(string dbQuery, OleDbConnection dbConn, OleDbTransaction dbTrans, params OleDbParameter[] parameters)
        {
            using (var dbComm = new OleDbCommand(dbQuery, dbConn))
            {
                if (parameters != null)
                    dbComm.Parameters.AddRange(parameters);
                if (dbTrans != null)
                    dbComm.Transaction = dbTrans;
                await dbComm.ExecuteNonQueryAsync().ConfigureAwait(false);
            }
        }
