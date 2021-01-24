     using System;
     using System.Data;
     using System.Data.SqlClient;
     namespace Portal.WebApp.Models
     {
         public class DbBlobSaver
         {
             #region Public Methods
             public void Execute(byte[] fileBytes)
             {
                 using (var dbConnection = new SqlConnection("Data Source = .; Initial Catalog = BlobsDatabase; Integrated Security = SSPI"))
                 {
                     var command = BuildCommand(dbConnection);
                     var blobParameter = BuildParameter(fileBytes);
                     command.Parameters.Add(blobParameter);
                     try
                     {
                         command.Connection.Open();
                         command.ExecuteNonQuery();
                     }
                     catch (Exception ex)
                     {
                         // Log errors here
                     }
                     finally
                     {
                         command.Connection.Close();
                     }
                 }
             }
             #endregion
             #region Private Methods
             private SqlParameter BuildParameter(byte[] fileBytes)
             {
                 var blobParameter = new SqlParameter("@BlobFile", SqlDbType.Binary);
                 blobParameter.Value = fileBytes;
                 return blobParameter;
             }
             private SqlCommand BuildCommand(SqlConnection connection)
             {
                 var command = new SqlCommand();
                 command.Connection = connection;
                 command.CommandType = CommandType.Text;
                 command.CommandText = "INSERT INTO BlobsTable(BlobFile)" + "VALUES (@BlobFile)";
                 return command;
             }
             #endregion
         }
     }
