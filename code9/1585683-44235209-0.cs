    // **********************************
    int counter = 0; // set up the counter
    // **********************************
     foreach (string s in context.Request.Files)
        {
    		
    		
            HttpPostedFile file = context.Request.Files[s];
            //  int fileSizeInBytes = file.ContentLength;
            string fileName = file.FileName;
            string fileExtension = file.ContentType;
            if (!string.IsNullOrEmpty(fileName))
            {
            
    			// **********************************
    			counter++; // increment the counter
          // **********************************
    			
                fileExtension = System.IO.Path.GetExtension(fileName);
                str_image = "MyPHOTO_" + numFiles.ToString() + fileExtension;
                string pathToSave_100 = HttpContext.Current.Server.MapPath("/images/") + str_image;
                file.SaveAs(pathToSave_100);
                
    // **********************************
                Service.SaveImage(strFileName, context.Session["Id"].ToString(), counter); // add counter variable to the path.
    // **********************************
            }
        }
    	
    // **********************************
    // add a column variable and then add it to your column name. like string columnName = "img+columnCount"
    // **********************************
    public static void SaveImage(string strImage, string Id, int columnCount)
    {
        // **********************************
        string strSql = @"update tablename set img@columnName=@image where id=@Id";
        // **********************************
        
        SqlParameter[] objSqlParameter ={
                                           new SqlParameter("@strImage",strImage),
                                           new SqlParameter("@Id",Id)
                                       };
        SqlHelper.ExecuteNonQuery(strConnectionString, CommandType.Text, strSql, objSqlParameter);
    }
