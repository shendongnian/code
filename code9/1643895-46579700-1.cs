    public int insertStreamResponse(HttpPostedFile file)
        {
            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = "Data 
            Source=HOME\\MSQLEXPRESS2016;Initial Catalog=Evaluation;Integrated 
             Security=True";
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = "insert into responses values
            (ResponseId, (0X))";
            SqlParameter parameter;
            parameter = new System.Data.SqlClient.SqlParameter("@ResponseId", 
            System.Data.SqlDbType.UniqueIdentifier);
            parameter.Value = this.response.ResponseId;
            sqlCommand.Parameters.Add(parameter);
            SqlCommand helperCommand = new SqlCommand();
            sqlCommand.Transaction = sqlConnection.BeginTransaction();
            sqlCommand.ExecuteNonQuery();
            helperCommand.Connection = sqlConnection;
            helperCommand.Transaction = sqlCommand.Transaction;
            helperCommand.CommandText = "SELECT 
            GET_FILESTREAM_TRANSACTION_CONTEXT()";
            Object transactionContext = helperCommand.ExecuteScalar();
            helperCommand.CommandText = "SELECT ResponseImage.PathName() FROM 
            Responses WHERE [ResponseId] = @Id";
            parameter = new System.Data.SqlClient.SqlParameter("@Id", 
            System.Data.SqlDbType.UniqueIdentifier);
            helperCommand.Parameters.Add(parameter);
            helperCommand.Parameters["@Id"].Value = sqlCommand.Parameters
            ["@ResponseId"].Value;
            string filePathInServer = (string)helperCommand.ExecuteScalar();
            byte[] buffer = new byte[file.ContentLength];
            //read from the input file 
            Stream fileStream = file.InputStream;
            if (fileStream.CanRead)
                fileStream.Read(buffer, 0, file.ContentLength);
            else return 0;
            //write into the  file stream
            SqlFileStream sqlFileStream = new SqlFileStream(filePathInServer, 
            (byte[])transactionContext, System.IO.FileAccess.Write);
            if (sqlFileStream.CanWrite)
                sqlFileStream.Write(buffer, 0, file.ContentLength);
            else return 0;
            sqlCommand.Transaction.Commit();
            sqlConnection.Close();
            return 1;
        }
