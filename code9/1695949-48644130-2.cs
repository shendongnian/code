    using System.Collections.Generic;
      using System.Data.SqlClient;
      using System.Linq;
      using System.Web;
     namespace InsertFromAndroidToSql
      {
       public interface SAPI : ISAPI // have error 1
     {
         //SqlConnection dbConnection; // have error 2   this is fields in 
         // interface you are declaring comment it or remove it 
         void ServiceAPI();    // have error 3   declare it dont define its 
        // functionality in interface
        //{
        // dbConnection = DBConnect.getConnection();
        //}
    void CreateNewAccount( string Name, 
                           string userName, 
                           string password, 
                           string PhoneNumber, 
                           string CNIC); // have error 4  same remove its definition
      //{
      //  if (dbConnection.State.ToString()=="Closed")
      //  {
        //    dbConnection.Open();
      //  }
       // string query = "Insert Into UserDetails VALUE ('" + Name + "','" + 
      //userName + "', '" + password + "', '" + PhoneNumber + "', '" + CNIC + 
      //"');";
       // SqlCommand command = new SqlCommand(query, dbConnection);
       // command.ExecuteNonQuery();
       // dbConnection.Close();
      }
     }
