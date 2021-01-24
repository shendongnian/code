     using System.Collections.Generic;
     using System.Data.SqlClient;
     using System.Linq;
     using System.Web;
     namespace InsertFromAndroidToSql
      {
         public interface SAPI : ISAPI // have error 1
          {  
     
             void ServiceAPI();       
             void CreateNewAccount( string Name, 
                       string userName, 
                       string password, 
                       string PhoneNumber, 
                       string CNIC);
      }
     }
