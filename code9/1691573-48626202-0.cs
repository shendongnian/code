    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Services;
    using System.Data.SqlClient;
    
    [System.Web.Script.Services.ScriptService]
    public class WebService : System.Web.Services.>WebService {
        [WebMethod]
        public List<string> ShowCountryList(string sLookUP)
        {
            List<string> lstCountries = new List<string>();
    
            string sConnString = "Data Source=DNA;Persist Security Info=False;" +
                "Initial Catalog=DNA_CLASSIFIED;User Id=sa;Password=;Connect Timeout=30;";
    
            SqlConnection myConn = new SqlConnection(sConnString);
            SqlCommand objComm = new SqlCommand("SELECT CountryName FROM Country " + 
                "WHERE CountryName LIKE '%'+@LookUP+'%' ORDER BY CountryName", myConn);
            myConn.Open();
    
            objComm.Parameters.AddWithValue("@LookUP", sLookUP);
            SqlDataReader reader = objComm.ExecuteReader();
    
            while (reader.Read()) {
                lstCountries.Add(reader["CountryName"].ToString());
            }
            myConn.Close();  return lstCountries;
        }
    }
