    string filePath1 = "Img1.jpg"; //You'll do the same for the other two images
    Image img1 = new Image(string filePath1);
    Image img2 = new Image(string filePath2);
    Image img3 = new Image(string filePath3);
    List<Image> listOfImageCollection = new List<Image>();
    listOfImageCollection.Add(img1);
    listOfImageCollection.Add(img2);
    listOfImageCollection.Add(img3);
    
    DataTable dt = new DataTable();
    foreach(Image imgs in listOfImageCollection)
    {
        dt.DataSource = imgs;
        dt.DataBind();
    }
    string myConnectionString = "";
    SqlConnection mySQLConnection;
    SqlCommand mySQLCommand;
    SqlDataReader mySQLDataReader;
 
    myConnectionString = ConfigurationManager.ConnectionStrings["ConnectionStringToTheDB"].ConnectionString;
                    using (mySQLConnection = new SqlConnection(myConnectionString))
                    {
                        mySQLCommand = new SqlCommand("storedProcedureNameToGetValue", mySQLConnection);
                        mySQLCommand.CommandType = CommandType.StoredProcedure;
                        mySqlParameter = new SqlParameter();
                        mySqlParameter.ParameterName = "@Value";
                        mySqlParameter.Value = Value;
                        mySQLCommand.Parameters.Add(mySqlParameter);
                        mySQLConnection.Open();
                        mySQLDataReader = mySQLCommand.ExecuteReader();
    
                        //Create a class to hold your DB properties
                        ClassName classInstance = new ClassName();
                        while (mySQLDataReader.Read())
                        {
                            classInstance.Value = Convert.ToInt32(mySQLDataReader["DBColumnNameHoldingValue"]);                                           
                        }
                       
                    if(classInstance.Value == 1 && dt.Count == 1)
                    {
                      //Display one Image then follow the same procedure for the other conditions
                    }
                 }
