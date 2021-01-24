    //After objBulkReader = objOleDB.ExecuteReader();
     if (objBulkReader.HasRows)
            {
                while (objBulkReader.Read())
                {       string newname = objBulkReader[0].ToString();
                        string address= objBulkReader[1].ToString();
                        string country= objBulkReader[2].ToString();
                        string uploadedby=Session["uploader"].ToString();
                     //insert these into SQL db by SQL connection
                
                 }
          }
